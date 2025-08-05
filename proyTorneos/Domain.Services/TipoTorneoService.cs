using Data;
using Domain.Model;

namespace Domain.Services
{
    public class TipoTorneoService
    {
        public void Add(TipoTorneo tipoTorneo)
        {
            tipoTorneo.Id = GetNextId();
            TipoTorneoInMemory.TiposTorneos.Add(tipoTorneo);
        }

        public bool Delete(int id)
        {
            TipoTorneo tipoTorneoToDelete = TipoTorneoInMemory.TiposTorneos.Find(x => x.Id == id);
            
            if(tipoTorneoToDelete != null)
            {
                TipoTorneoInMemory.TiposTorneos.Remove(tipoTorneoToDelete);
                return true;
            }else { return false; }
        }

        public TipoTorneo Get(int id)
        {
            return TipoTorneoInMemory.TiposTorneos.Find(x => x.Id == id);

        }

        public IEnumerable<TipoTorneo> GetAll()
        {
            return TipoTorneoInMemory.TiposTorneos.ToList();
        }

        public bool Update(TipoTorneo tipoTorneo)
        {
            TipoTorneo tipoTorneoToUpdate = TipoTorneoInMemory.TiposTorneos.Find(x => x.Id == tipoTorneo.Id);
            if (tipoTorneoToUpdate != null)
            {
                tipoTorneoToUpdate.Id = tipoTorneo.Id;
                tipoTorneoToUpdate.Nombre = tipoTorneo.Nombre;
                tipoTorneoToUpdate.Descripcion = tipoTorneo.Descripcion;

                return true;
            }else { return false; }
        }
        public int GetNextId()
        {
            int nextId;
            if (TipoTorneoInMemory.TiposTorneos.Count > 0)
            {
                nextId = TipoTorneoInMemory.TiposTorneos.Max(x => x.Id) + 1;
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }



    }

    
}
