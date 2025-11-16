using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class EquipoRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Equipo equipo)
        {
            using var context = CreateContext();

            var usuario = context.Usuarios.Find(equipo.LiderId);

            if (usuario == null)
                throw new InvalidOperationException($"No existe el usuario líder con ID {equipo.LiderId}");

            equipo.Lider = usuario; //asignamos la entidad completa

            context.Equipos.Add(equipo);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();

            var equipo = context.Equipos
                .Include(e => e.Usuarios)  // Cargar los usuarios asociados
                .FirstOrDefault(e => e.Id == id);

            if (equipo == null)
                return false;

            // Eliminar relaciones en la tabla intermedia EquipoUsuarios
            equipo.Usuarios.Clear();
            context.SaveChanges();

            // Ahora si, eliminar el equipo
            context.Equipos.Remove(equipo);
            context.SaveChanges();

            return true;
        }

        public Equipo? Get(int id)
        {
            using var context = CreateContext();
            return context.Equipos
                .Include(e => e.Lider)
                .Include(e => e.Usuarios)
                .Include(e => e.Inscripciones)
                    .ThenInclude(i => i.Torneo)
                .FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Equipo> GetAll()
        {
            using var context = CreateContext();
            return context.Equipos
                .Include(e => e.Lider)
                .Include(e => e.Usuarios)
                .Include(e => e.Inscripciones)
                    .ThenInclude(i => i.Torneo)
                .ToList();
        }

        public bool Update(Equipo equipo)
        {
            using var context = CreateContext();
            var existeEquipo = context.Equipos.Find(equipo.Id);
            if (existeEquipo != null)
            {
                existeEquipo.SetNombre(equipo.Nombre);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        //Devuelve todos
        public IEnumerable<Equipo> GetEquiposPorLider(int usuarioId)
        {
            using var context = CreateContext();

            return context.Equipos
                .Include(e => e.Lider)
                .Include(e => e.Usuarios)
                .Include(e => e.Inscripciones)
                    .ThenInclude(i => i.Torneo)
                .Where(e => e.LiderId == usuarioId)
                .ToList();
        }

        //Solo devuelve uno
        public Equipo? GetEquipoPorLider(int usuarioId)
        {
            using var context = CreateContext();

            return context.Equipos
                .Include(e => e.Lider)
                .Include(e => e.Usuarios)
                    .ThenInclude(u => u.Inscripciones)
                        .ThenInclude(i => i.Torneo)
                .Include(e => e.Inscripciones)
                    .ThenInclude(i => i.Torneo)
                        .ThenInclude(t => t.TipoDeTorneo)
                .FirstOrDefault(e => e.LiderId == usuarioId);
        }


        public bool AddUsuariosAlEquipo(Equipo equipo)
        {
            using var context = CreateContext();

            var equipoExistente = context.Equipos
                .Include(e => e.Usuarios)
                .FirstOrDefault(e => e.Id == equipo.Id);

            if (equipoExistente == null)
                throw new ArgumentException("Equipo no encontrado.");

            // Agregar usuarios sin duplicar
            foreach (var usuario in equipo.Usuarios)
            {
                if (!equipoExistente.Usuarios.Any(u => u.Id == usuario.Id))
                {
                    // Adjuntar el usuario si no está siendo trackeado
                    context.Attach(usuario);
                    equipoExistente.Usuarios.Add(usuario);
                }
            }

            context.SaveChanges();
            return true;
        }

        public void EliminarJugadorDelEquipo(int equipoId, int usuarioId)
        {
            using var context = CreateContext();

            var equipo = context.Equipos
                .Include(e => e.Usuarios)
                .FirstOrDefault(e => e.Id == equipoId);

            var usuario = equipo.Usuarios.FirstOrDefault(u => u.Id == usuarioId);

            if (usuario != null)
            {
                // Esto elimina de la tabla intermedia EquipoUsuarios
                equipo.Usuarios.Remove(usuario);
                context.SaveChanges();
            }
        }

    }
}
