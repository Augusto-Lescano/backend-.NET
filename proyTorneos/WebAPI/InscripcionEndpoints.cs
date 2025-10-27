using Domain.Model;
using Domain.Services;
using DTOs;

namespace WebAPI
{
    public static class InscripcionEndpoints
    {
        public static void MapInscripcionEndpoints(this WebApplication app)
        {
            app.MapGet("/inscripciones/{id}", (int id) =>
            {
                InscripcionService inscripcionService = new InscripcionService();
                var inscripcion = inscripcionService.Get(id);

                if (inscripcion is null)
                    return Results.NotFound();

                var dtoResult = new InscripcionDTO
                {
                    Id = inscripcion.Id,
                    Estado = inscripcion.Estado,
                    Fecha = inscripcion.Fecha
                };
                return Results.Ok(dtoResult);
            })
            .WithName("GetInscripcion")
            .Produces<InscripcionDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/inscripciones", () =>
            {
                InscripcionService inscripcionService = new InscripcionService();
                var inscripciones = inscripcionService.GetAll();

                var dtosResult = inscripciones.Select(i => new InscripcionDTO
                {
                    Id = i.Id,
                    Estado = i.Estado,
                    Fecha = i.Fecha
                }).ToList();

                return Results.Ok(dtosResult);
            })
            .WithName("GetAllInscripciones")
            .Produces<IEnumerable<InscripcionDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/inscripciones", (InscripcionDTO dto) =>
            {
                try
                {
                    InscripcionService inscripcionService = new InscripcionService();
                    Inscripcion inscripcion = new Inscripcion(dto.Id, dto.Estado, dto.Fecha);
                    inscripcionService.Add(inscripcion);

                    var dtoResult = new InscripcionDTO
                    {
                        Id = inscripcion.Id,
                        Estado = inscripcion.Estado,
                        Fecha = inscripcion.Fecha
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

            app.MapPut("/inscripciones", (InscripcionDTO dto) =>
            {
                try
                {
                    InscripcionService inscripcionService = new InscripcionService();
                    var updated = inscripcionService.Update(dto);

                    if (!updated)
                        return Results.NotFound();

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

            app.MapDelete("/inscripciones/{id}", (int id) =>
            {
                InscripcionService inscripcionService = new InscripcionService();
                var deleted = inscripcionService.Delete(id);

                if (!deleted)
                    return Results.NotFound();

                return Results.NoContent();
            })
            .WithName("DeleteInscripcion")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
