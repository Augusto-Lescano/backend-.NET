using Data;
using Domain.Model;
using DTOs;
using Microsoft.EntityFrameworkCore;

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

            // ==== VALIDACIONES PREVIAS ====

            // Validar existencia de entidades relacionadas
            if (juegoRepository.GetOne(dto.JuegoId) == null)
                throw new ArgumentException($"El juego con ID {dto.JuegoId} no existe.");

            var tipoTorneo = tipoTorneoRepository.Get(dto.TipoDeTorneoId)
                ?? throw new ArgumentException($"El tipo de torneo con ID {dto.TipoDeTorneoId} no existe.");

            if (usuarioRepository.Get(usuarioConectadoId) == null)
                throw new ArgumentException($"El organizador con ID {usuarioConectadoId} no existe.");


            // Validaciones de fechas
            if (dto.FechaInicio.Date < DateTime.Now.Date)
                throw new InvalidOperationException("La fecha de inicio del torneo no puede ser anterior a hoy.");

            if (dto.FechaInicio >= dto.FechaFin)
                throw new InvalidOperationException("La fecha de inicio del torneo debe ser anterior a la fecha de fin.");

            if (dto.FechaInicioDeInscripciones > dto.FechaFinDeInscripciones)
                throw new InvalidOperationException("La fecha de inicio de inscripciones no puede ser posterior a la fecha de fin de inscripciones.");


            // ==== CREAR TORNEO ====
            var torneo = new Torneo(
                0,
                dto.Nombre,
                dto.DescripcionDeReglas,
                dto.CantidadDeJugadores,
                dto.FechaInicio,
                dto.FechaFin,
                dto.FechaInicioDeInscripciones,
                dto.FechaFinDeInscripciones,
                resultado: "Pendiente", //El resultado inicial siempre es "Pendiente"
                dto.Region
            );

            torneo.TipoDeTorneoId = dto.TipoDeTorneoId;
            torneo.JuegoId = dto.JuegoId;
            torneo.OrganizadorId = usuarioConectadoId;

            //El estado se calcula automáticamente dentro del constructor del Torneo (SetEstado)
            torneo = torneoRepository.Add(torneo);

            // ==== CREAR INSCRIPCIÓN ASOCIADA ====

            // Determinar estado de la inscripción según las fechas
            string estadoInscripcion;
            var hoy = DateTime.Now;

            if (dto.FechaInicioDeInscripciones > hoy)
                estadoInscripcion = "Pendiente";
            else if (dto.FechaFinDeInscripciones < hoy)
                estadoInscripcion = "Cerrada";
            else
                estadoInscripcion = "Abierta";

            //Crear inscripción asociada
            var inscripcion = new Inscripcion
            {
                FechaApertura = dto.FechaInicioDeInscripciones,
                FechaCierre = dto.FechaFinDeInscripciones,
                Estado = estadoInscripcion,
                TorneoId = torneo.Id,
            };

            inscripcionRepository.Add(inscripcion); //Se guarda inscripción

            //Vincular la inscripción con el torneo
            torneo.InscripcionId = inscripcion.Id;
            torneoRepository.Update(torneo);

            //Preparar DTO de respuesta
            dto.Id = torneo.Id;
            dto.OrganizadorId = usuarioConectadoId;
            dto.InscripcionId = inscripcion.Id;
            dto.TipoTorneoNombre = tipoTorneo.Nombre;
            dto.Estado = torneo.Estado; //devolver el estado calculado
            dto.Resultado = torneo.Resultado;

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
            var torneoExistente = torneoRepository.GetOne(dto.Id)
                ?? throw new ArgumentException($"No se encontró el torneo con Id {dto.Id}.");

            // ==== VALIDACIONES ====
            if (dto.FechaInicio.Date < DateTime.Now.Date)
                throw new InvalidOperationException("La fecha de inicio del torneo no puede ser anterior a hoy.");

            if (dto.FechaInicio >= dto.FechaFin)
                throw new InvalidOperationException("La fecha de inicio del torneo debe ser anterior a la fecha de fin.");

            if (dto.FechaInicioDeInscripciones > dto.FechaFinDeInscripciones)
                throw new InvalidOperationException("La fecha de inicio de inscripciones no puede ser posterior a la fecha de fin de inscripciones.");

            // ==== ACTUALIZAR ====
            torneoExistente.Nombre = dto.Nombre;
            torneoExistente.DescripcionDeReglas = dto.DescripcionDeReglas;
            torneoExistente.CantidadDeJugadores = dto.CantidadDeJugadores;
            torneoExistente.FechaInicio = dto.FechaInicio;
            torneoExistente.FechaFin = dto.FechaFin;
            torneoExistente.FechaInicioDeInscripciones = dto.FechaInicioDeInscripciones;
            torneoExistente.FechaFinDeInscripciones = dto.FechaFinDeInscripciones;
            torneoExistente.Resultado = dto.Resultado ?? torneoExistente.Resultado;
            torneoExistente.Region = dto.Region;
            torneoExistente.JuegoId = dto.JuegoId;
            torneoExistente.TipoDeTorneoId = dto.TipoDeTorneoId;

            //recalcular estado automáticamente
            torneoExistente.SetEstado();

            return torneoRepository.Update(torneoExistente);
        }

        //Actualiza solo la fecha de inscripcion (desde inscripcion)
        public void ActualizarFechasDeInscripcion(int torneoId, DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
                throw new InvalidOperationException("La fecha de inicio de inscripción no puede ser posterior a la fecha de fin.");

            var torneoRepository = new TorneoRepository();
            var torneo = torneoRepository.GetOne(torneoId)
                ?? throw new ArgumentException($"No se encontró el torneo con Id {torneoId}");

            torneoRepository.ActualizarSoloFechasInscripcion(torneoId, fechaInicio, fechaFin);
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
