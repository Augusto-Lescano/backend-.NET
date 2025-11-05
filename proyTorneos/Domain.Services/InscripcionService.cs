using Data;
using Domain.Model;
using DTOs;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services
{
    public class InscripcionService
    {
        public void Add(Inscripcion inscripcion)
        {
            var inscripcionRepository = new InscripcionRepository();
            inscripcionRepository.Add(inscripcion);
        }

        public bool Delete(int id)
        {
            var inscripcionRepository = new InscripcionRepository();
            return inscripcionRepository.Delete(id);
        }

        public InscripcionDTO? Get(int id)
        {
            var inscripcionRepository = new InscripcionRepository();
            Inscripcion? inscripcion = inscripcionRepository.Get(id);

            if (inscripcion == null)
                return null;

            return new InscripcionDTO
            {
                Id = inscripcion.Id,
                Estado = inscripcion.Estado,
                FechaApertura = inscripcion.FechaApertura,
                FechaCierre = inscripcion.FechaCierre,
                TorneoId = inscripcion.TorneoId,
                TorneoNombre = inscripcion.Torneo?.Nombre ?? "(sin torneo)",
                TipoTorneoNombre = inscripcion.Torneo?.TipoDeTorneo?.Nombre ?? "(sin tipo)"
            };
        }

        public IEnumerable<InscripcionDTO> GetAll()
        {
            var inscripcionRepository = new InscripcionRepository();

            return inscripcionRepository.GetAll().Select(inscripcion => new InscripcionDTO
            {
                Id = inscripcion.Id,
                Estado = inscripcion.Estado,
                FechaApertura = inscripcion.FechaApertura,
                FechaCierre = inscripcion.FechaCierre,
                TorneoId = inscripcion.TorneoId,
                TorneoNombre = inscripcion.Torneo?.Nombre ?? "(sin torneo)"
            }).ToList();
        }

        public bool Update(InscripcionDTO dto)
        {
            var inscripcionRepository = new InscripcionRepository();

            if (inscripcionRepository != null)
            {
                Inscripcion inscripcion = new Inscripcion(dto.Id, dto.Estado, dto.FechaApertura, dto.FechaCierre);
                return inscripcionRepository.Update(inscripcion);
            }
            else
            {
                return false;
            }
        }

        public void InscribirUsuario(int usuarioId, int inscripcionId)
        {
            var inscripcionRepository = new InscripcionRepository();
            var usuarioRepository = new UsuarioRepository();

            var inscripcion = inscripcionRepository.Get(inscripcionId);

            if (inscripcion == null)
                throw new ArgumentException("Inscripción no encontrada.");

            string estado = inscripcion.Estado?.Trim().ToLower() ?? "";

            if (estado != "abierto" && estado != "abierta")
                throw new InvalidOperationException("La inscripción no está abierta.");

            var usuario = usuarioRepository.Get(usuarioId);

            if (usuario == null)
                throw new ArgumentException("Usuario no encontrado.");

            // Verificar tipo de torneo: solo jugadores en torneos individuales
            var tipo = inscripcion.Torneo.TipoDeTorneo?.Nombre?.ToLower() ?? "";
            bool esIndividual = tipo.Contains("1v1") || tipo.Contains("individual") || tipo.Contains("battle royale individual");

            if (!esIndividual)
                throw new InvalidOperationException("Este torneo es por equipos. Solo se pueden inscribir equipos, no jugadores individuales.");

            // Verificar que el usuario no esté inscrito en otro torneo que se solape
            if (usuario.Inscripciones.Any(i =>
                (inscripcion.Torneo.FechaInicio < i.Torneo.FechaFin) &&
                (inscripcion.Torneo.FechaFin > i.Torneo.FechaInicio)))
            {
                throw new InvalidOperationException("El usuario ya tiene una inscripción en un torneo que se solapa en fechas.");
            }

            // Verificar que el usuario no esté inscrito en esta inscripción
            if (inscripcion.Usuarios.Any(u => u.Id == usuarioId))
                throw new InvalidOperationException("El usuario ya está inscrito en esta inscripción.");

            // Verificar que el usuario no pertenezca a un equipo ya inscrito
            if (inscripcion.Equipos.Any(e => e.Usuarios.Any(u => u.Id == usuarioId)))
                throw new InvalidOperationException("El usuario pertenece a un equipo que ya está inscrito en esta inscripción.");

            // Verificar límite máximo de jugadores
            int totalActual = inscripcion.Usuarios.Count + inscripcion.Equipos.Sum(e => e.Usuarios.Count);
            if (totalActual + 1 > inscripcion.Torneo.CantidadDeJugadores)
                throw new InvalidOperationException("No se puede inscribir, se alcanzó la cantidad máxima de jugadores.");

            inscripcion.Usuarios.Add(usuario);
            inscripcionRepository.Update(inscripcion);
        }

        public Equipo InscribirEquipo(int inscripcionId, int usuarioId)
        {
            var inscripcionRepository = new InscripcionRepository();
            var equipoRepository = new EquipoRepository();

            //Obtener inscripción
            var inscripcion = inscripcionRepository.Get(inscripcionId)
                ?? throw new ArgumentException("Inscripción no encontrada.");

            //Validar estado
            if (inscripcion.Estado?.ToLower() != "abierto" && inscripcion.Estado.ToLower() != "abierta")
                throw new InvalidOperationException("La inscripción no está abierta.");

            //Obtener equipo del líder
            var equipo = equipoRepository.GetEquipoPorLider(usuarioId)
                ?? throw new ArgumentException("El usuario no es líder de ningún equipo.");

            //Validar liderazgo
            if (equipo.LiderId != usuarioId)
                throw new InvalidOperationException("Solo el líder del equipo puede inscribirlo al torneo.");

            //Validar tipo de torneo
            var tipoTorneo = inscripcion.Torneo?.TipoDeTorneo?.Nombre?.ToLower() ?? "";
            bool esIndividual = tipoTorneo.Contains("1v1") || tipoTorneo.Contains("individual") || tipoTorneo.Contains("battle royale individual");

            if (esIndividual)
                throw new InvalidOperationException("Este torneo es individual. Solo se pueden inscribir jugadores, no equipos.");

            //Validar cantidad de jugadores según tipo de torneo
            int cantidadJugadores = equipo.Usuarios.Count;
            bool cantidadValida = tipoTorneo switch
            {
                var t when t.Contains("2v2") => cantidadJugadores == 2,
                var t when t.Contains("3v3") => cantidadJugadores == 3,
                var t when t.Contains("4v4") => cantidadJugadores == 4,
                var t when t.Contains("5v5") => cantidadJugadores == 5,
                var t when t.Contains("battle royale grupal") => cantidadJugadores <= 4,
                _ => false
            };

            if (!cantidadValida)
                throw new InvalidOperationException($"El equipo no cumple con la cantidad requerida de jugadores para un torneo '{inscripcion.Torneo?.TipoDeTorneo?.Nombre}'.");

            //Validar solapamiento de torneos de los jugadores
            foreach (var usuario in equipo.Usuarios)
            {
                bool tieneSolapamiento = usuario.Inscripciones.Any(i =>
                    (inscripcion.Torneo.FechaInicio < i.Torneo.FechaFin) &&
                    (inscripcion.Torneo.FechaFin > i.Torneo.FechaInicio));

                if (tieneSolapamiento)
                    throw new InvalidOperationException($"El usuario '{usuario.Nombre}' tiene otra inscripción en un torneo que se solapa.");
            }

            //Verificar si el equipo ya está inscrito
            if (inscripcion.Equipos.Any(e => e.Id == equipo.Id))
                throw new InvalidOperationException("El equipo ya está inscrito en esta inscripción.");

            //Verificar que los usuarios del equipo no estén inscritos individualmente
            foreach (var usuario in equipo.Usuarios)
            {
                if (inscripcion.Usuarios.Any(u => u.Id == usuario.Id))
                    throw new InvalidOperationException($"El usuario '{usuario.Nombre}' ya está inscrito individualmente en esta inscripción.");
            }

            //Verificar límite máximo de jugadores en el torneo
            int totalActual = inscripcion.Usuarios.Count + inscripcion.Equipos.Sum(e => e.Usuarios.Count);
            int nuevoTotal = totalActual + equipo.Usuarios.Count;

            if (nuevoTotal > inscripcion.Torneo.CantidadDeJugadores)
                throw new InvalidOperationException("No se puede inscribir el equipo, se alcanzó la cantidad máxima de jugadores.");

            //Registrar la inscripción
            inscripcion.Equipos.Add(equipo);
            inscripcionRepository.Update(inscripcion);

            return equipo;
        }


        public Inscripcion? GetInscripcion(int inscripcionId)
        {
            var repo = new InscripcionRepository();
            return repo.Get(inscripcionId);
        }
    }
}
