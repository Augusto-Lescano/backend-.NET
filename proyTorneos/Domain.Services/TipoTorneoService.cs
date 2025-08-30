using Data;
using Domain.Model;
using DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Services
{
    public class TipoTorneoService
    {
        public void Add(TipoTorneo tipoTorneo)
        {   
            var tipoTorneoRepository = new TipoTorneoRepository();
            tipoTorneoRepository.Add(tipoTorneo);
        }

        public bool Delete(int id)
        {
            var tipoTorneoRepository = new TipoTorneoRepository();
            return tipoTorneoRepository.Delete(id);
        }

        public TipoTorneoDTO Get(int id)
        {
            var tipoTorneoRepository = new TipoTorneoRepository();
            TipoTorneo? tipoTorneo = tipoTorneoRepository.Get(id);

            if (tipoTorneo == null)
                return null;

            return new TipoTorneoDTO
            {
                Id = tipoTorneo.Id,
                Nombre = tipoTorneo.Nombre,
                Descripcion = tipoTorneo.Descripcion,
            };
        }

        public IEnumerable<TipoTorneoDTO> GetAll()
        {
            var tipoTorneoRepository = new TipoTorneoRepository();
            return tipoTorneoRepository.GetAll().Select(tipoTorneo => new TipoTorneoDTO
            {
                Id = tipoTorneo.Id,
                Nombre = tipoTorneo.Nombre,
                Descripcion = tipoTorneo.Descripcion,
            }).ToList();
        }

        public bool Update(TipoTorneoDTO dto)
        {
            var tipoTorneoRepository = new TipoTorneoRepository();

            if (tipoTorneoRepository != null)
            {
                TipoTorneo tipoTorneo = new TipoTorneo(dto.Id, dto.Nombre, dto.Descripcion);
                return tipoTorneoRepository.Update(tipoTorneo);

            }
            else { return false; }
        }
    }  
}
