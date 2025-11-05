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
                    Nombre = equipo.Nombre,
                    LiderId = equipo.LiderId,
                    LiderNombre = equipo.LiderNombre,
                    Usuarios = equipo.Usuarios?.Select(u => new UsuarioDTO
                    {
                        Id = u.Id,
                        Nombre = u.NombreUsuario
                    }).ToList() ?? new List<UsuarioDTO>()
                };
                return Results.Ok(dtoResult);
            })
            .WithName("GetEquipo")
            .Produces<EquipoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/equipos/lider/{usuarioId}", (int usuarioId) =>
            {
                EquipoService equipoService = new EquipoService();
                var equipos = equipoService.GetEquiposPorLider(usuarioId);

                if (equipos == null || !equipos.Any())
                    return Results.NotFound(new { mensaje = "El líder no tiene equipos registrados." });

                var dtoResult = equipos.Select(e => new EquipoDTO
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    LiderId = e.LiderId,
                    LiderNombre = e.Lider?.NombreUsuario ?? "(sin nombre)",
                    Usuarios = e.Usuarios.Select(u => new UsuarioDTO
                    {
                        Id = u.Id,
                        Nombre = u.Nombre
                    }).ToList()
                }).ToList();

                return Results.Ok(dtoResult);
            })
            .WithName("GetEquiposDelLider")
            .Produces<List<EquipoDTO>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/equipos", () =>
            {
                EquipoService equipoService = new EquipoService();
                var equipos = equipoService.GetAll();

                var dtosResult = equipos.Select(e => new EquipoDTO
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    LiderId = e.LiderId,
                    LiderNombre = e.LiderNombre
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

                    //Crear el equipo con el líder asignado
                    Equipo equipo = new Equipo(dto.Id, dto.Nombre)
                    {
                        LiderId = dto.LiderId
                    };

                    equipoService.Add(equipo);

                    var dtoResult = new EquipoDTO
                    {
                        Id = equipo.Id,
                        Nombre = equipo.Nombre,
                        LiderId = equipo.LiderId
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


            //Agregar usuarios a un equipo
            app.MapPost("/equipos/{equipoId}/agregar-usuarios", async (int equipoId, List<int> usuariosIds) =>
            {
                try
                {
                    var equipoService = new EquipoService();
                    var equipoActualizado = equipoService.AgregarUsuariosAlEquipo(equipoId, usuariosIds);

                    return Results.Ok(new
                    {
                        mensaje = $"Se agregaron {usuariosIds.Count} usuarios al equipo '{equipoActualizado.Nombre}'",
                        equipo = new
                        {
                            equipoActualizado.Id,
                            equipoActualizado.Nombre,
                            Usuarios = equipoActualizado.Usuarios.Select(u => new { u.Id, u.Nombre })
                        }
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
            .WithName("AgregarUsuariosAlEquipo")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
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
