using Domain.Model;
using Data;

namespace Domain.Services
{
    public class UsuarioService
    {
        public void Add(Usuario usuario)
        {
            usuario.SetId(GetNextId());

            UsuarioInMemory.Usuarios.Add(usuario);
        }

        public bool Delete(int id)
        {
            Usuario? usuarioToDelete = UsuarioInMemory.Usuarios.Find(x => x.Id == id);

            if (usuarioToDelete != null)
            {
                UsuarioInMemory.Usuarios.Remove(usuarioToDelete);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Usuario Get(int id)
        {
            return UsuarioInMemory.Usuarios.Find(x => x.Id == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return UsuarioInMemory.Usuarios.ToList();
        }

        public bool Update(Usuario usuario)
        {
            Usuario? usuarioToUpdate = UsuarioInMemory.Usuarios.Find(x => x.Id == usuario.Id);

            if (usuarioToUpdate != null)
            {
                usuarioToUpdate.SetNombre(usuario.Nombre);
                usuarioToUpdate.SetApellido(usuario.Apellido);
                usuarioToUpdate.SetEmail(usuario.Email);
                usuarioToUpdate.SetPais(usuario.Pais);
                usuarioToUpdate.SetGamerTag(usuario.GamerTag);
                usuarioToUpdate.SetRol(usuario.Rol);

                return true;
            }
            else
            { return false; }
        }

        private static int GetNextId()
        {
            int nextId;

            if (UsuarioInMemory.Usuarios.Count > 0)
            {
                nextId = UsuarioInMemory.Usuarios.Max(x => x.Id) + 1;
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }
    }
}
