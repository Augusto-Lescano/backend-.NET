using System.Text.RegularExpressions;

namespace Domain.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Pais {  get; set; }
        public string GamerTag { get; set; }
        public string Rol {  get; set; }

        public Usuario() { }

        public Usuario(int id, string nombre, string apellido, string email, string pais, string gamerTag, string rol)
        {
            SetId(id);
            SetNombre(nombre);
            SetApellido(apellido);
            SetEmail(email);
            SetPais(pais);
            SetGamerTag(gamerTag);
            SetRol(rol);
        }

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

        public void SetPais(string pais)
        {
            if (string.IsNullOrWhiteSpace(pais))
                throw new ArgumentException("El pais no puede ser nulo o vacío.", nameof(pais));
            Pais = pais;
        }

        public void SetGamerTag(string gamerTag)
        {
            if (string.IsNullOrWhiteSpace(gamerTag))
                throw new ArgumentException("El gamerTag no puede ser nulo o vacío.", nameof(gamerTag));
            GamerTag = gamerTag;
        }

        public void SetRol(string rol)
        {
            if (string.IsNullOrWhiteSpace(rol))
                throw new ArgumentException("El rol no puede ser nulo o vacío.", nameof(rol));
            Rol = rol;
        }
    }
}
