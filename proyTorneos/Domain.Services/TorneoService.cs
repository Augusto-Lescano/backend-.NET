using Data;
using Domain.Model;
using DTOs;

namespace Domain.Services
{
    public class TorneoService
    {
        public TorneoDTO Add(TorneoDTO dto, int usuarioConectadoId)
        {
            var torneoRepository = new TorneoRepository();
            var inscripcionRepository = new InscripcionRepository();
            var juegoRepository = new JuegoRepository();
            var tipoTorneoRepository = new TipoTorneoRepository();
            var usuarioRepository = new UsuarioRepository();

            //Validaciones previas
            if (juegoRepository.GetOne(dto.JuegoId) == null)
                throw new ArgumentException($"El juego con ID {dto.JuegoId} no existe");

            var tipoTorneo = tipoTorneoRepository.Get(dto.TipoDeTorneoId)
                ?? throw new ArgumentException($"El tipo de torneo con ID {dto.TipoDeTorneoId} no existe");

            if (usuarioRepository.Get(usuarioConectadoId) == null)
                throw new ArgumentException($"El organizador con ID {usuarioConectadoId} no existe");

            //Crear torneo
            var torneo = new Torneo(
                0,
                dto.Nombre,
                dto.DescripcionDeReglas,
                dto.CantidadDeJugadores,
                dto.FechaInicio,
                dto.FechaFin,
                dto.FechaInicioDeInscripciones,
                dto.FechaFinDeInscripciones,
                dto.Resultado,
                dto.Region,
                dto.Estado
            );

            torneo.TipoDeTorneoId = dto.TipoDeTorneoId;
            torneo.JuegoId = dto.JuegoId;
            torneo.OrganizadorId = usuarioConectadoId;

            torneo = torneoRepository.Add(torneo); //Se guarda torneo

            //Crear inscripción asociada
            var inscripcion = new Inscripcion
            {
                FechaApertura = dto.FechaInicioDeInscripciones,
                FechaCierre = dto.FechaFinDeInscripciones,
                Estado = dto.Estado,
                TorneoId = torneo.Id,
            };

            inscripcionRepository.Add(inscripcion); //Se guarda inscripción

            //Actualizar torneo con el Id de inscripción
            torneo.InscripcionId = inscripcion.Id;
            torneoRepository.Update(torneo);

            // Preparar DTO de respuesta
            dto.Id = torneo.Id;
            dto.OrganizadorId = usuarioConectadoId;
            dto.InscripcionId = inscripcion.Id;
            dto.TipoTorneoNombre = tipoTorneo.Nombre; //Devolvemos el tipo de torneo

            return dto;
        }


        public bool Delete(int id)
        {
            var torneoRepository = new TorneoRepository();
            return torneoRepository.Delete(id);
        }

        public bool Update(TorneoDTO dto)
        {
            var torneoRepository = new TorneoRepository();
            var torneo = new Torneo(
                dto.Id,
                dto.Nombre,
                dto.DescripcionDeReglas,
                dto.CantidadDeJugadores,
                dto.FechaInicio,
                dto.FechaFin,
                dto.FechaInicioDeInscripciones,
                dto.FechaFinDeInscripciones,
                dto.Resultado,
                dto.Region,
                dto.Estado
            );
            return torneoRepository.Update(torneo);
        }

        public TorneoDTO GetOne(int id)
        {
            var torneoRepository = new TorneoRepository();
            var dto = torneoRepository.GetOne(id);

            return new TorneoDTO
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
                Estado = dto.Estado
            };
        }

        public IEnumerable<TorneoDTO> GetAll()
        {
            var torneoRepository = new TorneoRepository();
            var torneos = torneoRepository.GetAll();

            return torneos.Select(dto => new TorneoDTO
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
                JuegoId = dto.JuegoId,
                OrganizadorId = dto.OrganizadorId,
                TipoDeTorneoId = dto.TipoDeTorneoId,
                InscripcionId = dto.InscripcionId,
                JuegoNombre = dto.Juego?.Nombre ?? "(sin juego)",
                TipoTorneoNombre = dto.TipoDeTorneo?.Nombre ?? "(sin tipo)",
                OrganizadorNombre = dto.Organizador?.NombreUsuario ?? "(sin nombre)"
            }).ToList();
        }
    }
}
