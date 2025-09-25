using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DTOs
{
    public class UsuarioDTO // - Datos seguros para mostrar
    {
        // Solo datos que son SEGUROS de exponer via API
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Clave {  get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; }

        // NUNCA incluir password/hash
    }

    public class UsuarioCreateDTO // - Mínimo necesario para crear
    {
        // Solo datos que el usuario PROVEE al crear
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty; // Contraseña en texto (obligatoria)
        public string Pais { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Rol { get; set; } = "Usuario"; // Valor por defecto

        // El rol podría asignarse automáticamente
    }

    public class UsuarioUpdateDTO // - Flexibilidad para actualizar
    {
        public int Id { get; set; } // NECESARIO para actualizar
        public string? Nombre { get; set; }        // Opcional
        public string? Apellido { get; set; }      // Opcional  
        public string? Email { get; set; }         // Opcional
        public string? Clave { get; set; }         // Opcional (para cambiar contraseña)
        public string? Pais { get; set; }          // Opcional
        public string? NombreUsuario { get; set; } // Opcional
        public string? Rol { get; set; }           // Opcional
        public bool? Activo { get; set; }          // Opcional activar/desactivar
    }
}