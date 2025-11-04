namespace DTOs
{
    public class EquipoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int LiderId { get; set; }
        public string? LiderNombre { get; set; }
        public List<UsuarioDTO> Usuarios { get; set; } = new List<UsuarioDTO>();
    }
}
