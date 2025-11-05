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
                Nombre = equipo.Nombre,
                LiderId = equipo.LiderId,
                LiderNombre = equipo.Lider?.NombreUsuario ?? "(sin nombre)",
                Usuarios = equipo.Usuarios?.Select(u => new UsuarioDTO
                {
                    Id = u.Id,
                    NombreUsuario = u.NombreUsuario
                }).ToList() ?? new List<UsuarioDTO>()
            };
        }

        public IEnumerable<EquipoDTO> GetAll()
        {
            var equipoRepository = new EquipoRepository();
            return equipoRepository.GetAll().Select(equipo => new EquipoDTO
            {
                Id = equipo.Id,
                Nombre = equipo.Nombre,
                LiderId = equipo.LiderId,
                LiderNombre = equipo.Lider?.NombreUsuario ?? "(sin nombre)"
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

        public IEnumerable<Equipo> GetEquiposPorLider(int usuarioId)
        {
            var equipoRepository = new EquipoRepository();
            return equipoRepository.GetEquiposPorLider(usuarioId);
        }


        //Agregar usuarios al equipo llamando al repositorio
        public Equipo AgregarUsuariosAlEquipo(int equipoId, List<int> usuariosIds)
        {
            var equipoRepository = new EquipoRepository();
            var usuarioRepository = new UsuarioRepository();

            var equipo = equipoRepository.Get(equipoId)
                ?? throw new ArgumentException("Equipo no encontrado.");

            var usuarios = usuarioRepository.GetUsuariosPorIds(usuariosIds);

            if (usuarios == null || !usuarios.Any())
                throw new InvalidOperationException("No se encontraron usuarios válidos para agregar.");

            foreach (var usuario in usuarios)
            {
                if (!equipo.Usuarios.Any(u => u.Id == usuario.Id))
                {
                    equipo.Usuarios.Add(usuario);
                }
            }

            equipoRepository.AddUsuariosAlEquipo(equipo);

            return equipo;
        }

        public void EliminarJugadorDelEquipo(int equipoId, int usuarioId)
        {
            var equipoRepository = new EquipoRepository();
            var usuarioRepository = new UsuarioRepository();

            // Validar que existe el equipo
            var equipo = equipoRepository.Get(equipoId);
            if (equipo == null)
                throw new ArgumentException("Equipo no encontrado.");

            // Validar que el usuario existe en el equipo
            var usuario = equipo.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
            if (usuario == null)
                throw new ArgumentException("Usuario no encontrado en este equipo.");

            // Validar que no sea el líder
            if (usuarioId == equipo.LiderId)
                throw new InvalidOperationException("No se puede eliminar al líder del equipo.");

            // Llamar al repository para eliminar
            equipoRepository.EliminarJugadorDelEquipo(equipoId, usuarioId);
        }

    }
}
