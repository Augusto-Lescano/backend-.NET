namespace Domain.Model
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Equipo(int id, string nombre)
        {
            SetId(id);
            SetNombre(nombre);
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
        }

        public int? InscripcionId { get; set; }
        public Inscripcion Inscripcion { get; set; }
    }
}
