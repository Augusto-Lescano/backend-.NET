using Domain.Services;
using DTOs;


namespace WebAPI
{
    public static class JuegoEndpoints
    {
        public static void MapJuegoEndpoints(this WebApplication app)
        {
            app.MapGet("/juegos/{id}", (int id) =>
            {
                JuegoService juegoService = new JuegoService();

                JuegoDTO dto = juegoService.GetOne(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetJuego")
            .Produces<JuegoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/juegos", () =>
            {
                JuegoService juegoService = new JuegoService();

                var dtos = juegoService.GetAll();

                return Results.Ok(dtos);
            })
            .WithName("GetAllJuegos")
            .Produces<List<JuegoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/juegos", (JuegoDTO dto) =>
            {
                try
                {
                    JuegoService juegoService = new JuegoService();

                    JuegoDTO juegoDTO = juegoService.Add(dto);

                    return Results.Created($"/juegos/{juegoDTO.Id}", juegoDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddJuego")
            .Produces<JuegoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/juegos", (JuegoDTO dto) =>
            {
                try
                {
                    JuegoService juegoService = new JuegoService();

                    var found = juegoService.Update(dto);

                    if (!found)
                    {
                        return Results.NotFound();
                    }

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateJuego")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/juegos/{id}", (int id) =>
            {
                JuegoService juegoService = new JuegoService();

                var deleted = juegoService.Delete(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteJuego")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
