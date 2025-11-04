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
            SetEstado();
            FechaApertura = fechaApertura;
            FechaCierre = fechaCierre;
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetEstado()
        {
            if(FechaApertura > DateTime.Now && FechaCierre > DateTime.Now)
            {
                Estado = "Pronto";
            }else if (FechaCierre <= DateTime.Now)
            {
                Estado = "Finalizado"; 
            }else if(FechaApertura <= DateTime.Now && FechaCierre > DateTime.Now) 
            {
                Estado = "Abierta"; 
            }
            
        }
    }
}