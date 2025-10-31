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

        public void Add(Inscripcion inscripcion)
        {
            using var context = CreateContext();
            context.Inscripciones.Add(inscripcion);
            context.SaveChanges();
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
                .FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Inscripcion> GetAll()
        {
            using var context = CreateContext();

            //Actualiza estados antes de devolver los datos
            ActualizarEstados(context);

            return context.Inscripciones
                .Include(i => i.Torneo) //Muestra torneo relacionado
                .ToList();
        }

        public bool Update(Inscripcion inscripcion)
        {
            using var context = CreateContext();
            var existeInscripcion = context.Inscripciones.Find(inscripcion.Id);
            if (existeInscripcion != null)
            {
                existeInscripcion.FechaApertura = inscripcion.FechaApertura;
                existeInscripcion.FechaCierre = inscripcion.FechaCierre;
                existeInscripcion.SetEstado(); 
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void ActualizarEstados(TPIContext context)
        {
            var hoy = DateTime.Now;
            var inscripciones = context.Inscripciones.ToList();

            foreach (var insc in inscripciones)
            {
                string nuevoEstado;

                if (hoy < insc.FechaApertura)
                    nuevoEstado = "Pronto...";
                else if (hoy >= insc.FechaApertura && hoy <     insc.FechaCierre)
                    nuevoEstado = "Abierto";
                else
                    nuevoEstado = "Finalizado";

                if (insc.Estado != nuevoEstado)
                {
                    insc.Estado = nuevoEstado;
                    context.Inscripciones.Update(insc);
                }
            }
            context.SaveChanges();
        }
    }
}
