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


        public List<Usuario> GetUsuariosPorIds(List<int> ids)
        {
            using var context = CreateContext();
            return context.Usuarios
                          .Where(u => ids.Contains(u.Id))
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


        //Obtiene solo los usuarios que no esten en un equipo o en un torneo activo
        public IEnumerable<Usuario> GetUsuariosDisponibles()
        {
            using var context = CreateContext();

            var fechaActual = DateTime.Now;

            return context.Usuarios
                .Include(u => u.Equipos)
                .Include(u => u.Inscripciones)
                    .ThenInclude(i => i.Torneo)
                .Where(u =>
                    // No está en ningún equipo
                    !u.Equipos.Any() &&

                    // No tiene inscripciones en torneos activos
                    !u.Inscripciones.Any(i =>
                        i.Torneo.FechaInicio <= fechaActual &&
                        i.Torneo.FechaFin >= fechaActual))
                .ToList();
        }


    }
}
