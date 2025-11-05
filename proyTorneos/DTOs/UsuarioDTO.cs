using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Clave {  get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public DateTime FechaAlta { get; set; }
        public bool Admin { get; set; }

    }
}