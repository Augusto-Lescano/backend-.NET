using Data;
using Domain.Model;
using DTOs;

namespace Domain.Services
{
    public class InscripcionService
    {
        public void Add(Inscripcion inscripcion)
        {
            var inscripcionRepository = new InscripcionRepository();
            inscripcionRepository.Add(inscripcion);
        }

        public bool Delete(int id)
        {
            var inscripcionRepository = new InscripcionRepository();
            return inscripcionRepository.Delete(id);
        }

        public InscripcionDTO? Get(int id)
        {
            var inscripcionRepository = new InscripcionRepository();
            Inscripcion? inscripcion = inscripcionRepository.Get(id);

            if (inscripcion == null)
                return null;

            return new InscripcionDTO
            {
                Id = inscripcion.Id,
                Estado = inscripcion.Estado,
                FechaApertura = inscripcion.FechaApertura,
                FechaCierre = inscripcion.FechaCierre
            };
        }

        public IEnumerable<InscripcionDTO> GetAll()
        {
            var inscripcionRepository = new InscripcionRepository();
            return inscripcionRepository.GetAll().Select(inscripcion => new InscripcionDTO
            {
                Id = inscripcion.Id,
                Estado = inscripcion.Estado,
                FechaApertura = inscripcion.FechaApertura,
                FechaCierre = inscripcion.FechaCierre,
                TorneoId = inscripcion.TorneoId,
                TorneoNombre = inscripcion.Torneo?.Nombre ?? "(sin torneo)"
            }).ToList();
        }

        public bool Update(InscripcionDTO dto)
        {
            var inscripcionRepository = new InscripcionRepository();

            if (inscripcionRepository != null)
            {
                Inscripcion inscripcion = new Inscripcion(dto.Id, dto.Estado, dto.FechaApertura, dto.FechaCierre);
                return inscripcionRepository.Update(inscripcion);
            }
            else
            {
                return false;
            }
        }
    }
}
