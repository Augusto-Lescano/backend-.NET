using Data;
using Domain.Model;


namespace Domain.Services
{
    public class TorneoService
    {
        public void Add(Torneo torneo) {
            torneo.Id = GetNextId();
            TorneoInMemory.Torneos.Add(torneo);
        }
        public bool Delete(int id) {
            Torneo torneoToDelete = TorneoInMemory.Torneos.Find(x => x.Id == id);
            if (torneoToDelete != null)
            {
                TorneoInMemory.Torneos.Remove(torneoToDelete);
                return true;
            }
            else {
                return false;
            }
        }
        public Torneo Get(int id) {
            return TorneoInMemory.Torneos.Find(x => x.Id == id);
        }
        public IEnumerable<Torneo> GetAll() {
            return TorneoInMemory.Torneos.ToList();
        }
        public bool Update(Torneo torneo) {
            Torneo torneoToUpdate = TorneoInMemory.Torneos.Find(x=>x.Id==torneo.Id);
            if (torneoToUpdate != null)
            {
                torneoToUpdate.Id = torneo.Id;
                torneoToUpdate.Nombre = torneo.Nombre;
                torneoToUpdate.DescripcionDeReglas = torneo.DescripcionDeReglas;
                torneoToUpdate.CantidadDeJugadores = torneo.CantidadDeJugadores;
                torneoToUpdate.FechaInicio = torneo.FechaInicio;
                torneoToUpdate.FechaFin = torneo.FechaFin;
                torneoToUpdate.FechaInicioDeInscripciones = torneo.FechaInicioDeInscripciones;
                torneoToUpdate.FechaFinDeInscripciones = torneo.FechaFinDeInscripciones;
                torneoToUpdate.Resultado = torneo.Resultado;
                torneoToUpdate.Region = torneo.Region;
                torneoToUpdate.Estado = torneo.Estado;
                return true;
            }
            else {
                return false;
            }
        }
        public int GetNextId() {
            int nextId;
            if (TorneoInMemory.Torneos.Count > 0)
            {
                nextId = TorneoInMemory.Torneos.Max(x => x.Id) + 1;
                
            }
            else {
                nextId = 1;
            }

            return nextId;
        }
    }
}
