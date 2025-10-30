using Domain.Model;
using Microsoft.EntityFrameworkCore;
namespace Data
{
    public class TorneoRepository
    {
        private TPIContext CreateContext() {
            return new TPIContext();
        }

        public Torneo GetOne(int id) {
            using var context = CreateContext();
            return context.Torneos.Find(id);
        }

        public IEnumerable<Torneo> GetAll() {
            using var context = CreateContext();
            return context.Torneos
                .Include(t => t.Juego)
                .Include(t => t.TipoDeTorneo)
                .Include(t => t.Inscripcion)
                .Include(t => t.Organizador)
                .ToList();
        }

        public void Add(Torneo torneo)
        {
            using var context = CreateContext();

            //Guarda el torneo
            context.Torneos.Add(torneo);
            context.SaveChanges();


            // comentado momentaneamente
            /*Crea inscripción automáticamente
            var estado = CalcularEstadoInscripcion(torneo.FechaInicioDeInscripciones, torneo.FechaFinDeInscripciones);

            var inscripcion = new Inscripcion
            {
                FechaApertura = torneo.FechaInicioDeInscripciones,
                FechaCierre = torneo.FechaFinDeInscripciones,
                Estado = estado,
                TorneoId = torneo.Id
            };

            context.Inscripciones.Add(inscripcion);
            context.SaveChanges();*/ 
        }

        public bool Delete(int id) {
            using var context = CreateContext();
            var torneo = context.Torneos.Find(id);
            if (torneo != null)
            {
                context.Torneos.Remove(torneo);
                context.SaveChanges();
                return true;
            }
            else {
                return false;
            }
        }

        public bool Update(Torneo torneo)
        {
            using var context = CreateContext();
            var torneoToUpdate = context.Torneos.Find(torneo.Id);
            if (torneoToUpdate != null)
            {
                torneoToUpdate.Nombre= torneo.Nombre;
                torneoToUpdate.DescripcionDeReglas = torneo.DescripcionDeReglas;
                torneoToUpdate.CantidadDeJugadores = torneo.CantidadDeJugadores;
                torneoToUpdate.FechaInicio = torneo.FechaInicio;
                torneoToUpdate.FechaFin = torneo.FechaFin;
                torneoToUpdate.FechaInicioDeInscripciones = torneo.FechaInicioDeInscripciones;
                torneoToUpdate.Resultado = torneo.Resultado;
                torneoToUpdate.Region = torneo.Region;
                torneoToUpdate.Estado = torneo.Estado;
                context.SaveChanges();
                return true;
            }
            else
            { 
                return false; 
            }
        }

        private string CalcularEstadoInscripcion(DateTime apertura, DateTime cierre)
        {
            var hoy = DateTime.Now;
            if (hoy < apertura) return "Pronto...";
            if (hoy >= apertura && hoy < cierre) return "Abierto";
            return "Finalizado";
        }
    }
}
