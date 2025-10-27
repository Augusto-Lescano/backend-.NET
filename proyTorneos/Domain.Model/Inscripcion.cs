namespace Domain.Model
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }

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
    }
}