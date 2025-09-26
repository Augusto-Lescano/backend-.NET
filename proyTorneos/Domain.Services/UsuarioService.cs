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
                Pais = usuario.Pais,
                NombreUsuario = usuario.NombreUsuario,
                Rol = usuario.Rol,
                FechaAlta = usuario.FechaAlta,
                Activo = usuario.Activo
            });
        }

        public bool Update(UsuarioDTO updateDto)
        {
            var usuarioRepository = new UsuarioRepository();
            var usuario = usuarioRepository.Get(updateDto.Id);
            if (usuario == null)
                return false;

            #region comentarios
            /*
            Flexibilidad: El usuario actualiza solo lo que necesita
            Seguridad: No se sobrescriben datos accidentalmente
            Performance: Solo se actualizan los campos modificados
            UX: Mejor experiencia para el usuario final
             */
            #endregion
            // Actualizar SOLO si se proporciona valor
            if (!string.IsNullOrWhiteSpace(updateDto.Nombre))
                usuario.SetNombre(updateDto.Nombre);

            if (!string.IsNullOrWhiteSpace(updateDto.Apellido))
                usuario.SetApellido(updateDto.Apellido);

            if (!string.IsNullOrWhiteSpace(updateDto.Email))
                usuario.SetEmail(updateDto.Email);

            if (!string.IsNullOrWhiteSpace(updateDto.Clave))
                usuario.SetClave(updateDto.Clave);

            if (!string.IsNullOrWhiteSpace(updateDto.Pais))
                usuario.SetPais(updateDto.Pais);

            if (!string.IsNullOrWhiteSpace(updateDto.NombreUsuario))
                usuario.SetNombreUsuario(updateDto.NombreUsuario);

            if (!string.IsNullOrWhiteSpace(updateDto.Rol))
                usuario.SetRol(updateDto.Rol);

          

            return usuarioRepository.Update(usuario);
        }
    }
}
