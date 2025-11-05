using Domain.Model;
using Domain.Services;
using DTOs;

namespace WebAPI
{
    public static class InscripcionEndpoints
    {
        public static void MapInscripcionEndpoints(this WebApplication app)
        {
            //Obtener inscripción por ID
            app.MapGet("/inscripciones/{id}", (int id) =>
            {
                var service = new InscripcionService();
                var inscripcion = service.Get(id);

                if (inscripcion is null)
                    return Results.NotFound(new { error = "Inscripción no encontrada." });

                return Results.Ok(inscripcion);
            })
            .WithName("GetInscripcion")
            .Produces<InscripcionDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();


            //Obtener todas las inscripciones
            app.MapGet("/inscripciones", () =>
            {
                var service = new InscripcionService();
                var inscripciones = service.GetAll();

                return Results.Ok(inscripciones);
            })
            .WithName("GetAllInscripciones")
            .Produces<IEnumerable<InscripcionDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();


            //Crear nueva inscripción
            app.MapPost("/inscripciones", (InscripcionDTO dto) =>
            {
                try
                {
                    var service = new InscripcionService();
                    var inscripcion = new Inscripcion(dto.Id, dto.Estado, dto.FechaApertura, dto.FechaCierre);

                    service.Add(inscripcion);

                    var dtoResult = new InscripcionDTO
                    {
                        Id = inscripcion.Id,
                        Estado = inscripcion.Estado,
                        FechaApertura = inscripcion.FechaApertura,
                        FechaCierre = inscripcion.FechaCierre
                    };

                    return Results.Created($"/inscripciones/{dtoResult.Id}", dtoResult);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddInscripcion")
            .Produces<InscripcionDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();


            //Inscribir usuario individual
            app.MapPost("/inscripciones/{inscripcionId}/usuarios/{usuarioId}", (int inscripcionId, int usuarioId) =>
            {
                try
                {
                    var service = new InscripcionService();
                    var inscripcion = service.GetInscripcion(inscripcionId);

                    if (inscripcion == null)
                        return Results.NotFound(new { error = "Inscripción no encontrada." });

                    service.InscribirUsuario(usuarioId, inscripcionId);

                    string nombreTorneo = inscripcion.Torneo?.Nombre ?? "(torneo desconocido)";
                    return Results.Ok(new { mensaje = $"Te has inscrito al torneo {nombreTorneo}" });
                }
                catch (ArgumentException ex)
                {
                    return Results.NotFound(new { error = ex.Message });
                }
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("InscribirUsuario")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();


            // Inscribir equipo (por el líder)
            app.MapPost("/inscripciones/{inscripcionId}/equipos/{equipoId}", (int inscripcionId, int equipoId) =>
            {
                try
                {
                    var service = new InscripcionService();
                    var inscripcion = service.GetInscripcion(inscripcionId);

                    if (inscripcion == null)
                        return Results.NotFound(new { error = "Inscripción no encontrada." });

                    var equipo = service.InscribirEquipo(inscripcionId, equipoId);

                    string nombreTorneo = inscripcion.Torneo?.Nombre ?? "(torneo desconocido)";
                    return Results.Ok(new
                    {
                        mensaje = $"Tu equipo '{equipo.Nombre}' ha sido inscrito al torneo '{nombreTorneo}'."
                    });
                }
                catch (ArgumentException ex)
                {
                    return Results.NotFound(new { error = ex.Message });
                }
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("InscribirEquipo")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();


            //Actualizar inscripción
            app.MapPut("/inscripciones", (InscripcionDTO dto) =>
            {
                try
                {
                    var service = new InscripcionService();
                    bool updated = service.Update(dto);

                    if (!updated)
                        return Results.NotFound(new { error = "Inscripción no encontrada para actualizar." });

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateInscripcion")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();


            //Eliminar inscripción
            app.MapDelete("/inscripciones/{id}", (int id) =>
            {
                var service = new InscripcionService();
                bool deleted = service.Delete(id);

                if (!deleted)
                    return Results.NotFound(new { error = "Inscripción no encontrada para eliminar." });

                return Results.NoContent();
            })
            .WithName("DeleteInscripcion")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            // Eliminar usuario de inscripción
            app.MapDelete("/inscripciones/{inscripcionId}/usuarios/{usuarioId}", (int inscripcionId, int usuarioId) =>
            {
                try
                {
                    var service = new InscripcionService();
                    service.EliminarUsuarioDeInscripcion(inscripcionId, usuarioId);
                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.NotFound(new { error = ex.Message });
                }
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("EliminarUsuarioDeInscripcion");

            // Eliminar equipo de inscripción
            app.MapDelete("/inscripciones/{inscripcionId}/equipos/{equipoId}", (int inscripcionId, int equipoId) =>
            {
                try
                {
                    var service = new InscripcionService();
                    service.EliminarEquipoDeInscripcion(inscripcionId, equipoId);
                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.NotFound(new { error = ex.Message });
                }
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("EliminarEquipoDeInscripcion");
        }
    }
}
