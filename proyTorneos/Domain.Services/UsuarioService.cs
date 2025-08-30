using Domain.Model;
using Data;
using DTOs;

namespace Domain.Services
{
    public class UsuarioService
    {
        public UsuarioDTO Add(UsuarioDTO dto)
        {
            var usuarioRepository = new usuarioRepository();

            // Validar que el email no esté duplicado
            if (usuarioRepository.EmailExists(dto.Email))
            {
                throw new ArgumentException($"Ya existe un usuario con el Email '{dto.Email}'.");
            }

            var fechaAlta = DateTime.Now;
            Usuario cliente = new Usuario(0, dto.Nombre, dto.Apellido, dto.Email, dto.Pais, dto.GamerTag, dto.Rol, fechaAlta);

            usuarioRepository.Add(usuario);

            dto.Id = usuario.Id;
            dto.FechaAlta = usuario.FechaAlta;

            return dto;
        }

        public bool Delete(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            return usuarioRepository.Delete(id);
        }

        public UsuarioDTO Get(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            Usuario? usuario = usuarioRepository.Get(id);

            if (usuario == null)
                return null;

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Pais = usuario.Pais,
                GamerTag = usuario.GamerTag,
                Rol = usuario.Rol,
                FechaAlta = usuario.FechaAlta
            };
        }

        public IEnumerable<UsuarioDTO> GetAll()
        {
            var usuarioRepository = new UsuarioRepository();
            var usuarios = usuarioRepository.GetAll();

            return usuarios.Select(usuario => new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Pais = usuario.Pais,
                GamerTag = usuario.GamerTag,
                Rol = usuario.Rol,
                FechaAlta = usuario.FechaAlta
            }).ToList();
        }

        public bool Update(UsuarioDTO dto)
        {
            var clienteRepository = new UsuarioRepository();

            // Validar que el email no esté duplicado (excluyendo el usuario actual)
            if (usuarioRepository.EmailExists(dto.Email, dto.Id))
            {
                throw new ArgumentException($"Ya existe otro usuario con el Email '{dto.Email}'.");
            }

            Usuario usuario = new Usuario(dto.Id, dto.Nombre, dto.Apellido, dto.Email, dto.Pais, dto.GamerTag, dto.Rol, dto.FechaAlta);
            return usuarioRepository.Update(usuario);
        }

        public IEnumerable<UsuarioDTO> GetByCriteria(UsuarioCriteriaDTO criteriaDTO)
        {
            var usuarioRepository = new UsuarioRepository();

            // Mapear DTO a Domain Model
            var criteria = new UsuarioCriteria(criteriaDTO.Texto);

            // Llamar al repositorio
            var usuarios = usuarioRepository.GetByCriteria(criteria);

            // Mapear Domain Model a DTO
            return usuarios.Select(c => new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Pais = usuario.Pais,
                GamerTag = usuario.GamerTag,
                Rol = usuario.Rol,
                FechaAlta = usuario.FechaAlta
            });
        }
    }
}
