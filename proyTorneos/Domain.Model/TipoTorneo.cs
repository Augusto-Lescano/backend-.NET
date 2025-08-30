
namespace Domain.Model
{
    public class TipoTorneo
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public TipoTorneo(int id, string nombre, string descripcion)
        {
            SetId(id);
            SetNombre(nombre);
            SetDescripcion(descripcion);
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

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripcion no puede ser nula o vacía.", nameof(descripcion));
            Descripcion = descripcion;
        }
    }
}
