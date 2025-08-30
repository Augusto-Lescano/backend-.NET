using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;


namespace Data
{
    public class TipoTorneoRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(TipoTorneo tipoTorneo)
        {
            using var context = CreateContext();
            context.TipoTorneos.Add(tipoTorneo);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var tipoTorneo = context.TipoTorneos.Find(id);
            if (tipoTorneo != null)
            {
                context.TipoTorneos.Remove(tipoTorneo);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public TipoTorneo? Get(int id)
        {
            using var context = CreateContext();
            return context.TipoTorneos.Find(id);
        }

        public IEnumerable<TipoTorneo> GetAll()
        {
            using var context = CreateContext();
            return context.TipoTorneos.ToList();
        }

        public bool Update(TipoTorneo tipoTorneo)
        {
            using var context = CreateContext();
            var existeTipoTorneo = context.TipoTorneos.Find(tipoTorneo.Id);
            if (existeTipoTorneo != null)
            {
                existeTipoTorneo.SetNombre(tipoTorneo.Nombre);
                existeTipoTorneo.SetDescripcion(tipoTorneo.Descripcion);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
