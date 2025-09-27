using Domain.Model;
using Data;
using DTOs;

namespace Domain.Services
{
    public class UsuarioService
    {
        public UsuarioDTO Add(UsuarioDTO createDto)
        {
            var usuarioRepository = new UsuarioRepository();

            var fechaAlta = DateTime.Now;
            Usuario usuario = new Usuario(0, createDto.Nombre, createDto.Apellido, createDto.Email, createDto.Clave, createDto.Pais, createDto.NombreUsuario, createDto.Rol, fechaAlta, true);

            usuarioRepository.Add(usuario);

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Clave = usuario.Clave,
                Pais = usuario.Pais,
                NombreUsuario = usuario.NombreUsuario,
                Rol = usuario.Rol,
                FechaAlta = usuario.FechaAlta,
                Activo = usuario.Activo
            };
        }

        public bool Delete(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            return usuarioRepository.Delete(id);
        }

        public UsuarioDTO? Get(int id)
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
                Clave = usuario.Clave,
                Pais = usuario.Pais,
                NombreUsuario = usuario.NombreUsuario,
                Rol = usuario.Rol,
                FechaAlta = usuario.FechaAlta,
                Activo = usuario.Activo
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
                Clave = usuario.Clave,
                Pais = usuario.Pais,
                NombreUsuario = usuario.NombreUsuario,
                Rol = usuario.Rol,
                FechaAlta = usuario.FechaAlta,
                Activo = usuario.Activo
            });
        }

        public bool Update(UsuarioDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();

            if (usuarioRepository != null)
            {
                Usuario usuario = new Usuario(dto.Id, dto.Nombre, dto.Apellido, dto.Email, dto.Clave, dto.Pais, dto.NombreUsuario, dto.Rol, dto.FechaAlta, dto.Activo);
                return usuarioRepository.Update(usuario);
            }
            else { return false; }
        }
    }
}
