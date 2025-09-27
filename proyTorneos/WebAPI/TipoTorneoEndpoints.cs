using Domain.Model;
using Domain.Services;
using DTOs;

namespace WebAPI
{
    public static class TipoTorneoEndpoints
    {
        public static void MapTipoTorneoEndpoints(this WebApplication app)
        {
            app.MapGet("/tipoTorneos/{id}", (int id) =>
            {
                TipoTorneoService tipoTorneoService = new TipoTorneoService();
                var tipoToreno = tipoTorneoService.Get(id);

                if (tipoToreno is null)
                {
                    return Results.NotFound();
                }

                var dtoResult = new DTOs.TipoTorneoDTO
                {
                    Id = tipoToreno.Id,
                    Nombre = tipoToreno.Nombre,
                    Descripcion = tipoToreno.Descripcion
                };
                return Results.Ok(dtoResult);
            })
            .WithName("GetTipoTorneo")
            .Produces<DTOs.TipoTorneoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/tipoTorneos", () =>
            {
                TipoTorneoService tipoTorneoService = new TipoTorneoService();
                var tipoTorenos = tipoTorneoService.GetAll();

                var dtosResult = tipoTorenos.Select(tipoTorneo => new DTOs.TipoTorneoDTO
                {
                    Id = tipoTorneo.Id,
                    Nombre = tipoTorneo.Nombre,
                    Descripcion = tipoTorneo.Descripcion
                }).ToList();
                return Results.Ok(dtosResult);
            })
            .WithName("GetAllTipoTorneo")
            .Produces<DTOs.TipoTorneoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapPost("/tipoTorneos", (DTOs.TipoTorneoDTO dto) =>
            {
                try
                {
                    TipoTorneoService tipoTorneoService = new TipoTorneoService();
                    TipoTorneo tipoTorneo = new TipoTorneo(dto.Id, dto.Nombre, dto.Descripcion);
                    tipoTorneoService.Add(tipoTorneo);

                    var dtoResult = new DTOs.TipoTorneoDTO
                    {
                        Id = tipoTorneo.Id,
                        Nombre = tipoTorneo.Nombre,
                        Descripcion = tipoTorneo.Descripcion
                    };
                    return Results.Created($"/tipoTorneos/{dtoResult.Id}", dtoResult);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddTipoTorneo")
            .Produces<DTOs.TipoTorneoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapPut("/tipoTorneos", (TipoTorneoDTO dto) => {
                try
                {
                    TipoTorneoService tipoTorneoService = new TipoTorneoService();
                    var found = tipoTorneoService.Update(dto);
                    if (!found)
                    {
                        return Results.NotFound();
                    }
                    else
                    {

                        return Results.NoContent();
                    }

                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateTipoTorneo")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/tipoTorneos/{id}", (int id) =>
            {
                TipoTorneoService tipoTorneoService = new TipoTorneoService();
                var tipoTorneoToDelete = tipoTorneoService.Delete(id);

                if (!tipoTorneoToDelete)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            })
            .WithName("DeleteTipoTorneo")
            .Produces<DTOs.TipoTorneoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
