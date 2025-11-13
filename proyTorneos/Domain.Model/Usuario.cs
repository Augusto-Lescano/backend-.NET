using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;


namespace Domain.Model
{
    public class Usuario
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string Pais {  get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Admin { get; set; }
        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
        public ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();

        public Usuario(int id, string nombre, string apellido, string email, string clave, string pais, string nombreUsuario, DateTime fechaAlta, bool admin = false)
        {
            SetId(id);
            SetNombre(nombre);
            SetApellido(apellido);
            SetEmail(email);
            SetClave(clave);
            SetPais(pais);
            SetNombreUsuario(nombreUsuario);       
            SetFechaAlta(fechaAlta);
            SetAdmin(admin);
        }

        // Constructor privado sin parámetros requerido por Entity Framework
        // EF no puede usar el constructor público porque 'password' no existe como propiedad en BD
        // - En BD guardamos: ClaveHash y Salt
        // - El Domain Model recibe: password (y lo hashea internamente)
        // Por eso EF necesita este constructor para crear instancias desde la BD
        public Usuario() { }

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

            if (clave.Length < 8 || clave.Length > 15)  
                throw new ArgumentException("La clave debe tener entre 8 y 15 caracteres.", nameof(clave));

            Clave = clave; 
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

        public void SetAdmin(bool admin)
        {
            Admin = admin;
        }

        public void SetFechaAlta(DateTime fechaAlta)
        {
            if (fechaAlta == default)
            {
                throw new ArgumentException("La fecha de alta no puede ser nula.", nameof(fechaAlta));
            }

            FechaAlta = fechaAlta;
        }

      
    }
}
