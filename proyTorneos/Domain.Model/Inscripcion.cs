namespace Domain.Model
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public string Estado { get; set; } 
        public DateTime FechaApertura { get; set; }
        public DateTime FechaCierre { get; set; }
        public int TorneoId { get; set; }
        public Torneo? Torneo { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
        
        public Inscripcion() { }

        public Inscripcion(int id, string estado, DateTime fechaApertura, DateTime fechaCierre)
        {
            SetId(id);
            FechaApertura = fechaApertura;
            FechaCierre = fechaCierre;
            SetEstado();
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetEstado()
        {
            var ahora = DateTime.Now;

            if (FechaApertura > ahora)
                Estado = "Pendiente"; //Inscripción aún no empezó
            else if (FechaCierre < ahora)
                Estado = "Cerrada"; //Ya terminó el período
            else
                Estado = "Abierta"; //Está en curso
        }
    }
}