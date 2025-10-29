namespace Domain.Model
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
        public Inscripcion() { }
        public Inscripcion(int id, string estado, DateTime fecha)
        {
            SetId(id);
            SetEstado(estado);
            Fecha = fecha;
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetEstado(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException("El estado no puede ser nulo o vacío.", nameof(estado));
            Estado = estado;
        }


        public int TorneoId { get; set; }
        public Torneo Torneo { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

        public ICollection<Equipo> Equipos { get; set; } = new List<Equipo>(); 

    }
}