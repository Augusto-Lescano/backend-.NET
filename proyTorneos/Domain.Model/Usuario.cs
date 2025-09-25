using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.Model
{
    public class Usuario
    {
        // Identificador - inmutable después de creación
        public int Id { get; private set; }
        // Datos críticos que requieren validación
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Email { get; private set; }
        public string ClaveHash { get; private set; }
        public string Salt { get; private set; }
        public string Pais {  get; private set; }
        public string NombreUsuario { get; private set; }
        public string Rol {  get; private set; }
        // Estado 
        public DateTime FechaAlta { get; private set; }
        public bool Activo { get; private set; }

        public Usuario(int id, string nombre, string apellido, string email, string clave, string pais, string nombreUsuario, string rol, DateTime fechaAlta, bool activo = true)
        {
            SetId(id);
            SetNombre(nombre);
            SetApellido(apellido);
            SetEmail(email);
            SetClave(clave);
            SetPais(pais);
            SetNombreUsuario(nombreUsuario);
            SetRol(rol);
            SetFechaAlta(fechaAlta);
            SetActivo(activo);
        }

        // Constructor privado sin parámetros requerido por Entity Framework
        // EF no puede usar el constructor público porque 'password' no existe como propiedad en BD
        // - En BD guardamos: ClaveHash y Salt
        // - El Domain Model recibe: password (y lo hashea internamente)
        // Por eso EF necesita este constructor para crear instancias desde la BD
        private Usuario() { }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede ser nulo o vacío.", nameof(apellido));
            Apellido = apellido;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email no puede ser nulo o vacío.", nameof(email));

            // Expresión regular para validar formato de email básico
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(email, emailPattern))
                throw new ArgumentException("El formato del email no es válido. Debe contener '@' y un dominio válido (ej: usuario@dominio.com).", nameof(email));

            Email = email;
        }

        public void SetClave(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("La clave no puede ser nula o vacía.", nameof(clave));

            if (clave.Length < 6)
                throw new ArgumentException("La clave debe tener al menos 6 caracteres.", nameof(clave));

            Salt = GenerateSalt();
            ClaveHash = HashPassword(clave, Salt);
        }

        public void SetPais(string pais)
        {
            if (string.IsNullOrWhiteSpace(pais))
                throw new ArgumentException("El pais no puede ser nulo o vacío.", nameof(pais));
            Pais = pais;
        }

        public void SetNombreUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario no puede ser nulo o vacío.", nameof(nombreUsuario));

            if (nombreUsuario.Length < 3)
                throw new ArgumentException("El nombre de usuario debe tener al menos 3 caracteres.", nameof(nombreUsuario));

            NombreUsuario = nombreUsuario;
        }

        public void SetRol(string rol)
        {
            if (string.IsNullOrWhiteSpace(rol))
                throw new ArgumentException("El rol no puede ser nulo o vacío.", nameof(rol));
            Rol = rol;
        }

        public void SetFechaAlta(DateTime fechaAlta)
        {
            if (fechaAlta == default)
            {
                throw new ArgumentException("La fecha de alta no puede ser nula.", nameof(fechaAlta));
            }
            FechaAlta = fechaAlta;
        }

        public void SetActivo(bool activo)
        {
            Activo = activo;
        }

        public bool ValidarClave(string clave) // Verifica si la contraseña es correcta durante el login
        {
            if (string.IsNullOrWhiteSpace(clave))
                return false;

            // Hashear la contraseña ingresada con el SALT almacenado
            string hashedInput = HashPassword(clave, Salt);

            // Comparar con el hash almacenado en la base de datos
            return ClaveHash == hashedInput;
        }

        private static string GenerateSalt() // Generador de Sal
        {
            byte[] saltBytes = new byte[32]; // Crea un array de 32 bytes(256 bits)

            RandomNumberGenerator.Fill(saltBytes); // Se llena con números aleatorios criptográficamente seguros

            return Convert.ToBase64String(saltBytes); // Convierte a string Base64 para almacenamiento

            // Resultado ejemplo: "aB3x9mLpQrStUvWxYz1AbCdEfGhIjKlMnOpQrStUvWxYz1=="
        }

        private static string HashPassword(string clave, string salt) // Hasheador seguro
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(
                clave,                               // Contraseña en texto plano
                Convert.FromBase64String(salt),      // Salt convertido de vuelta a bytes
                10000,                               // Nro de iteraciones
                HashAlgorithmName.SHA256);           // Algoritmo de hash

            byte[] hashBytes = pbkdf2.GetBytes(32); // Genera 32 bytes (256 bits) de hash

            return Convert.ToBase64String(hashBytes); // Convierte a string para almacenar
        }
    }
}
