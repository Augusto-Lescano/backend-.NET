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
            context.Equipos.Add(equipo);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var equipo = context.Equipos.Find(id);
            if (equipo != null)
            {
                context.Equipos.Remove(equipo);
                context.SaveChanges();
                return true;
            }
            return false;
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

        public Equipo? GetEquipoPorLider(int usuarioId)
        {
            using var context = CreateContext();
            return context.Equipos
                          .Include(e => e.Usuarios)
                          .FirstOrDefault(e => e.LiderId == usuarioId);
        }

    }
}
