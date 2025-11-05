using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class InscripcionRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public Inscripcion Add(Inscripcion inscripcion)
        {
            using var context = CreateContext();
            context.Inscripciones.Add(inscripcion);
            context.SaveChanges();
            return inscripcion;
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var inscripcion = context.Inscripciones.Find(id);

            if (inscripcion != null)
            {
                context.Inscripciones.Remove(inscripcion);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public Inscripcion? Get(int id)
        {
            using var context = CreateContext();

            return context.Inscripciones
                .Include(i => i.Torneo)
                    .ThenInclude(t => t.TipoDeTorneo)
                .Include(i => i.Usuarios)
                    .ThenInclude(u => u.Inscripciones)
                .Include(i => i.Equipos)
                    .ThenInclude(e => e.Usuarios)
                .FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Inscripcion> GetAll()
        {
            using var context = CreateContext();

            return context.Inscripciones
                .Include(i => i.Torneo)
                    .ThenInclude(t => t.TipoDeTorneo)
                .Include(i => i.Usuarios)
                .Include(i => i.Equipos)
                .ToList();
        }

        public bool Update(Inscripcion inscripcion)
        {
            using var context = CreateContext();
            var existente = context.Inscripciones
                .Include(i => i.Usuarios)
                .Include(i => i.Equipos)
                .FirstOrDefault(i => i.Id == inscripcion.Id);

            if (existente == null)
                return false;

            existente.FechaApertura = inscripcion.FechaApertura;
            existente.FechaCierre = inscripcion.FechaCierre;
            existente.SetEstado();

            context.SaveChanges();
            return true;
        }

        public Inscripcion? GetInscripcionConDetalles(int inscripcionId)
        {
            using var context = CreateContext();

            return context.Inscripciones
                .Include(i => i.Torneo)
                    .ThenInclude(t => t.TipoDeTorneo)
                .Include(i => i.Usuarios)
                .Include(i => i.Equipos)
                    .ThenInclude(e => e.Usuarios)
                .FirstOrDefault(i => i.Id == inscripcionId);
        }

        
        public bool AgregarUsuarioAInscripcion(int inscripcionId, int usuarioId)
        {
            using var context = CreateContext();

            var inscripcion = context.Inscripciones
                .Include(i => i.Usuarios)
                .FirstOrDefault(i => i.Id == inscripcionId);

            var usuario = context.Usuarios.Find(usuarioId);

            if (inscripcion == null || usuario == null)
                return false;

            inscripcion.Usuarios.Add(usuario);
            context.SaveChanges();
            return true;
        }

        public bool AgregarEquipoAInscripcion(int inscripcionId, int equipoId)
        {
            using var context = CreateContext();

            var inscripcion = context.Inscripciones
                .Include(i => i.Equipos)
                .FirstOrDefault(i => i.Id == inscripcionId);

            var equipo = context.Equipos.Find(equipoId);

            if (inscripcion == null || equipo == null)
                return false;

            inscripcion.Equipos.Add(equipo);
            context.SaveChanges();
            return true;
        }

        public void EliminarUsuarioDeInscripcion(int inscripcionId, int usuarioId)
        {
            using var context = CreateContext();

            var inscripcion = context.Inscripciones
                .Include(i => i.Usuarios)
                .FirstOrDefault(i => i.Id == inscripcionId);

            var usuario = inscripcion.Usuarios.FirstOrDefault(u => u.Id == usuarioId);

            if (usuario != null)
            {
                // Esto elimina de la tabla intermedia UsuariosInscripciones
                inscripcion.Usuarios.Remove(usuario);
                context.SaveChanges();
            }
        }

        public void EliminarEquipoDeInscripcion(int inscripcionId, int equipoId)
        {
            using var context = CreateContext();

            var inscripcion = context.Inscripciones
                .Include(i => i.Equipos)
                .FirstOrDefault(i => i.Id == inscripcionId);

            var equipo = inscripcion.Equipos.FirstOrDefault(e => e.Id == equipoId);

            if (equipo != null)
            {
                // Esto elimina de la tabla intermedia EquiposInscripciones
                inscripcion.Equipos.Remove(equipo);
                context.SaveChanges();
            }
        }
    }
}
