using Data;
using Domain.Model;
using DTOs;


namespace Domain.Services
{
    public class TorneoService
    {
        public TorneoDTO Add(TorneoDTO dto) {
            
            var torneoRepository = new TorneoRepository();
            var inscripcionRepository = new InscripcionRepository();

            var torneo = new Torneo(0, dto.Nombre, dto.DescripcionDeReglas,dto.CantidadDeJugadores, dto.FechaInicio, dto.FechaFin, dto.FechaInicioDeInscripciones, dto.FechaFinDeInscripciones, dto.Resultado, dto.Region, dto.Estado);


            torneo.TipoDeTorneoId = dto.TipoDeTorneoId;
            torneoRepository.Add(torneo);

            var inscripcion = new Inscripcion
            {
                Estado = "Abierta",
                Fecha = DateTime.Now,
                TorneoId = torneo.Id
            };

            inscripcionRepository.Add(inscripcion);

            dto.Id = torneo.Id; 
            dto.InscripcionId = inscripcion.Id;
            return dto;
        }

        public bool Delete(int id) {
            var torneoRepository = new TorneoRepository();
            return torneoRepository.Delete(id);
        }

        public bool Update(TorneoDTO dto) {
            var torneoRepository = new TorneoRepository();

            var torneo = new Torneo(dto.Id, dto.Nombre, dto.DescripcionDeReglas, dto.CantidadDeJugadores, dto.FechaInicio, dto.FechaFin, dto.FechaInicioDeInscripciones, dto.FechaFinDeInscripciones, dto.Resultado, dto.Region, dto.Estado);

            return torneoRepository.Update(torneo);
        }

        public TorneoDTO GetOne(int id) {
            var torneoRepository = new TorneoRepository();
            var dto = torneoRepository.GetOne(id);
            return new TorneoDTO {
                Id=dto.Id,
                Nombre=dto.Nombre,
                DescripcionDeReglas=dto.DescripcionDeReglas,
                CantidadDeJugadores=dto.CantidadDeJugadores,
                FechaInicio=dto.FechaInicio,
                FechaFin=dto.FechaFin,
                FechaInicioDeInscripciones=dto.FechaInicioDeInscripciones,
                FechaFinDeInscripciones=dto.FechaFinDeInscripciones,
                Resultado=dto.Resultado,
                Region=dto.Region,
                Estado=dto.Estado,
            };
        }

        public IEnumerable<TorneoDTO> GetAll() {
            var torneoRepository = new TorneoRepository();
            var torneos = torneoRepository.GetAll();
            return (from dto in torneos
                   select new TorneoDTO
                   {
                       Id = dto.Id,
                       Nombre = dto.Nombre,
                       DescripcionDeReglas = dto.DescripcionDeReglas,
                       CantidadDeJugadores = dto.CantidadDeJugadores,
                       FechaInicio = dto.FechaInicio,
                       FechaFin = dto.FechaFin,
                       FechaInicioDeInscripciones = dto.FechaInicioDeInscripciones,
                       FechaFinDeInscripciones = dto.FechaFinDeInscripciones,
                       Resultado = dto.Resultado,
                       Region = dto.Region,
                       Estado = dto.Estado,
                   }).ToList();

        }
    }
}
