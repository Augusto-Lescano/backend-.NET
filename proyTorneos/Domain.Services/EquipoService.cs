using Data;
using Domain.Model;
using DTOs;

namespace Domain.Services
{
    public class EquipoService
    {
        public void Add(Equipo equipo)
        {
            var equipoRepository = new EquipoRepository();
            equipoRepository.Add(equipo);
        }

        public bool Delete(int id)
        {
            var equipoRepository = new EquipoRepository();
            return equipoRepository.Delete(id);
        }

        public EquipoDTO? Get(int id)
        {
            var equipoRepository = new EquipoRepository();
            Equipo? equipo = equipoRepository.Get(id);

            if (equipo == null)
                return null;

            return new EquipoDTO
            {
                Id = equipo.Id,
                Nombre = equipo.Nombre
            };
        }

        public IEnumerable<EquipoDTO> GetAll()
        {
            var equipoRepository = new EquipoRepository();
            return equipoRepository.GetAll().Select(equipo => new EquipoDTO
            {
                Id = equipo.Id,
                Nombre = equipo.Nombre
            }).ToList();
        }

        public bool Update(EquipoDTO dto)
        {
            var equipoRepository = new EquipoRepository();

            if (equipoRepository != null)
            {
                Equipo equipo = new Equipo(dto.Id, dto.Nombre);
                return equipoRepository.Update(equipo);
            }
            else
            {
                return false;
            }
        }
    }
}
