using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            using var context = CreateContext();
            return context.Usuarios
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
                existingUsuario.SetPais(usuario.Pais);
                existingUsuario.SetGamerTag(usuario.GamerTag);
                existingUsuario.SetRol(usuario.Rol);

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EmailExists(string email, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Usuarios.Where(c => c.Email.ToLower() == email.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }
            return query.Any();
        }
    }
}
