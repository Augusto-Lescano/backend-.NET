using Domain.Model;
using Domain.Services;
using DTOs;

namespace WebAPI
{
    public static class EquipoEndpoints
    {
        public static void MapEquipoEndpoints(this WebApplication app)
        {
            app.MapGet("/equipos/{id}", (int id) =>
            {
                EquipoService equipoService = new EquipoService();
                var equipo = equipoService.Get(id);

                if (equipo is null)
                    return Results.NotFound();

                var dtoResult = new EquipoDTO
                {
                    Id = equipo.Id,
                    Nombre = equipo.Nombre
                };
                return Results.Ok(dtoResult);
            })
            .WithName("GetEquipo")
            .Produces<EquipoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/equipos", () =>
            {
                EquipoService equipoService = new EquipoService();
                var equipos = equipoService.GetAll();

                var dtosResult = equipos.Select(e => new EquipoDTO
                {
                    Id = e.Id,
                    Nombre = e.Nombre
                }).ToList();

                return Results.Ok(dtosResult);
            })
            .WithName("GetAllEquipos")
            .Produces<IEnumerable<EquipoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/equipos", (EquipoDTO dto) =>
            {
                try
                {
                    EquipoService equipoService = new EquipoService();
                    Equipo equipo = new Equipo(dto.Id, dto.Nombre);
                    equipoService.Add(equipo);

                    var dtoResult = new EquipoDTO
                    {
                        Id = equipo.Id,
                        Nombre = equipo.Nombre
                    };
                    return Results.Created($"/equipos/{dtoResult.Id}", dtoResult);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddEquipo")
            .Produces<EquipoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/equipos", (EquipoDTO dto) =>
            {
                try
                {
                    EquipoService equipoService = new EquipoService();
                    var updated = equipoService.Update(dto);

                    if (!updated)
                        return Results.NotFound();

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateEquipo")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/equipos/{id}", (int id) =>
            {
                EquipoService equipoService = new EquipoService();
                var deleted = equipoService.Delete(id);

                if (!deleted)
                    return Results.NotFound();

                return Results.NoContent();
            })
            .WithName("DeleteEquipo")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
