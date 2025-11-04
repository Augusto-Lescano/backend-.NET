using Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public class UsuarioRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Usuario usuario)
        {
            using var context = CreateContext();

            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();

            var usuario = context.Usuarios.Find(id);
            if (usuario != null)
            {
                context.Usuarios.Remove(usuario);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Usuario? Get(int id)
        {
            using var context = CreateContext();

            return context.Usuarios
                .Include(u => u.Inscripciones)
                    .ThenInclude(i => i.Torneo)
                .Include(u => u.Equipos)
                    .ThenInclude(e => e.Inscripciones)
                .FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            using var context = CreateContext();

            return context.Usuarios
                .Include(u => u.Inscripciones)
                    .ThenInclude(i => i.Torneo)
                .Include(u => u.Equipos)
                    .ThenInclude(e => e.Inscripciones)
                .ToList();
        }

        public bool Update(Usuario usuario)
        {
            using var context = CreateContext();

            var existingUsuario = context.Usuarios.Find(usuario.Id);
            if (existingUsuario != null)
            {
                existingUsuario.SetNombre(usuario.Nombre);
                existingUsuario.SetApellido(usuario.Apellido);
                existingUsuario.SetEmail(usuario.Email);
                existingUsuario.SetClave(usuario.Clave);
                existingUsuario.SetPais(usuario.Pais);
                existingUsuario.SetNombreUsuario(usuario.NombreUsuario);
                
                existingUsuario.SetFechaAlta(usuario.FechaAlta);
                existingUsuario.SetAdmin(usuario.Admin);


                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
