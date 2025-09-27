using Domain.Services;
using DTOs;

namespace WebAPI
{
    public static class TorneoEndpoints
    {
        public static void MapTorneoEndpoints(this WebApplication app)
        {
            app.MapGet("/torneos/{id}", (int id) => {
                TorneoService torneoService = new TorneoService();
                TorneoDTO dto = torneoService.GetOne(id);
                if (dto == null)
                {
                    Results.NotFound();
                }
                else
                {
                    Results.Ok(dto);
                }
            })
            .WithName("GetTorneo")
            .Produces<TorneoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/torneos", () => {
                TorneoService torneoService = new TorneoService();
                var dtos = torneoService.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllTorneos")
            .Produces<List<TorneoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/torneos", (TorneoDTO dto) => {
                try
                {
                    TorneoService torneoService = new TorneoService();

                    TorneoDTO torneoDTO = torneoService.Add(dto);

                    return Results.Created($"/usuarios/{torneoDTO.Id}", torneoDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddTorneo")
            .Produces<TorneoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/torneos", (TorneoDTO dto) => {
                try
                {
                    TorneoService torneoService = new TorneoService();
                    var found = torneoService.Update(dto);
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
            .WithName("UpdateTorneo")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/torneos/{id}", (int id) => {
                TorneoService torneoService = new TorneoService();
                var deleted = torneoService.Delete(id);
                if (!deleted)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.NoContent();
                }
            })
            .WithName("DeleteTorneo")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
