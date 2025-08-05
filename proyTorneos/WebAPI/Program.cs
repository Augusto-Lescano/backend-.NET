using Microsoft.AspNetCore.OpenApi;
using System.ComponentModel.DataAnnotations;
using Domain.Model;
using Domain.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //Falta configurar de manera correcta        
    app.UseHttpLogging();
}
app.UseHttpsRedirection();

#region MetodosHttpUsuario
app.MapGet("/usuarios/{id}", (int id) =>
{
    UsuarioService usuarioService = new UsuarioService(); 

    Usuario usuario = usuarioService.Get(id);

    if (usuario == null)
    {
        return Results.NotFound();
    }
        
    var dto = new DTOs.Usuario
    {
        Id = usuario.Id,
        Nombre = usuario.Nombre,
        Apellido = usuario.Apellido,
        Email = usuario.Email,
        Pais = usuario.Pais,
        GamerTag = usuario.GamerTag,
        Rol = usuario.Rol
    };

    return Results.Ok(dto);
})
.WithName("GetUsuario")
.Produces<DTOs.Usuario>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.MapGet("/usuarios", () =>
{
    UsuarioService usuarioService1 = new UsuarioService();

    var usuarios = usuarioService1.GetAll();

    var dtos = usuarios.Select(usuario => new DTOs.Usuario
    {
        Id = usuario.Id,
        Nombre = usuario.Nombre,
        Apellido = usuario.Apellido,
        Email = usuario.Email,
        Pais = usuario.Pais,
        GamerTag = usuario.GamerTag,
        Rol = usuario.Rol
    }).ToList();

    return Results.Ok(dtos);
})
.WithName("GetAllUsuarios")
.Produces<List<DTOs.Usuario>>(StatusCodes.Status200OK)
.WithOpenApi();

app.MapPost("/usuarios", (DTOs.Usuario dto) =>
{
    try
    {
        UsuarioService usuarioService = new UsuarioService();

        Usuario usuario = new Usuario(dto.Id, dto.Nombre, dto.Apellido, dto.Email, dto.Pais, dto.GamerTag, dto.Rol);

        usuarioService.Add(usuario);

        var dtoResultado = new DTOs.Usuario
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Apellido = usuario.Apellido,
            Email = usuario.Email,
            Pais = usuario.Pais,
            GamerTag = usuario.GamerTag,
            Rol = usuario.Rol
        };

        return Results.Created($"/usuarios/{dtoResultado.Id}", dtoResultado);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("AddUsuario")
.Produces<DTOs.Usuario>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest)
.WithOpenApi();

app.MapPut("/usuarios/{id}", (int id, DTOs.Usuario dto) =>
{
    try
    {
        UsuarioService usuarioService = new UsuarioService();

        Usuario usuario = new Usuario(id, dto.Nombre, dto.Apellido, dto.Email, dto.Pais, dto.GamerTag, dto.Rol);

        var found = usuarioService.Update(usuario);

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
.WithName("UpdateUsuario")
.Produces(StatusCodes.Status404NotFound)
.Produces(StatusCodes.Status400BadRequest)
.WithOpenApi();

app.MapDelete("/usuarios/{id}", (int id) =>
{
    UsuarioService usuarioService = new UsuarioService();

    var deleted = usuarioService.Delete(id);

    if (!deleted)
    {
        return Results.NotFound();
    }

    return Results.NoContent();

})
.WithName("DeleteUsuario")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();
#endregion

#region MetodosHttpTorneo
app.MapGet("/torneos/{id}", (int id) => {
    TorneoService torneoService = new TorneoService();
    Torneo torneo = torneoService.Get(id);
    if (torneo == null) {
        return Results.NotFound();
    }
    var dto = new DTOs.Torneo
    {
        Id = torneo.Id,
        Nombre = torneo.Nombre,
        DescripcionDeReglas = torneo.DescripcionDeReglas,
        CantidadDeJugadores = torneo.CantidadDeJugadores,
        FechaInicio = torneo.FechaInicio,
        FechaFin = torneo.FechaFin,
        FechaInicioDeInscripciones = torneo.FechaInicioDeInscripciones,
        FechaFinDeInscripciones = torneo.FechaFinDeInscripciones,
        Resultado = torneo.Resultado,
        Region = torneo.Region,
        Estado = torneo.Estado
    };
    return Results.Ok(dto);
})
.WithName("GetTorneo")
.Produces<DTOs.Torneo>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.MapGet("/torneos", () => {
    TorneoService torneoService = new TorneoService();
    var torneos = torneoService.GetAll();
    var dtos = torneos.Select(torneo => new DTOs.Torneo {
        Id = torneo.Id,
        Nombre = torneo.Nombre,
        DescripcionDeReglas = torneo.DescripcionDeReglas,
        CantidadDeJugadores = torneo.CantidadDeJugadores,
        FechaInicio = torneo.FechaInicio,
        FechaFin = torneo.FechaFin,
        FechaInicioDeInscripciones = torneo.FechaInicioDeInscripciones,
        FechaFinDeInscripciones = torneo.FechaFinDeInscripciones,
        Resultado = torneo.Resultado,
        Region = torneo.Region,
        Estado = torneo.Estado
    }).ToList();
    return Results.Ok(dtos);
})
.WithName("GetAllTorneos")
.Produces<List<DTOs.Torneo>>(StatusCodes.Status200OK)
.WithOpenApi();

app.MapPost("/torneos", (DTOs.Torneo dto) => {
    try
    {
        TorneoService torneoService = new TorneoService();
        Torneo torneo = new Torneo(
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
        torneoService.Add(torneo);
        var dtoResultado = new DTOs.Torneo
        {
            Id = torneo.Id,
            Nombre = torneo.Nombre,
            DescripcionDeReglas = torneo.DescripcionDeReglas,
            CantidadDeJugadores = torneo.CantidadDeJugadores,
            FechaInicio = torneo.FechaInicio,
            FechaFin = torneo.FechaFin,
            FechaInicioDeInscripciones = torneo.FechaInicioDeInscripciones,
            FechaFinDeInscripciones = torneo.FechaFinDeInscripciones,
            Resultado = torneo.Resultado,
            Region = torneo.Region,
            Estado = torneo.Estado
        };
        return Results.Created($"/usuarios/{dtoResultado.Id}", dtoResultado);
    }
    catch (ArgumentException ex) {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("AddTorneo")
.Produces<DTOs.Torneo>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest)
.WithOpenApi();

app.MapPut("/torneos/{id}",(int id, DTOs.Torneo dto) => {
    try
    {
        TorneoService torneoService = new TorneoService();
        Torneo torneo = new Torneo(
            id,
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
        var found = torneoService.Update( torneo );
        if (!found) {
            return Results.NotFound();
        }
        return Results.NoContent();

    }
    catch (ArgumentException ex) {
        return Results.BadRequest(new { error=ex.Message});
    }
})
.WithName("UpdateTorneo")
.Produces(StatusCodes.Status404NotFound)
.Produces(StatusCodes.Status400BadRequest)
.WithOpenApi();

app.MapDelete("/torneos/{id}",(int id) => {
    TorneoService torneoService = new TorneoService();
    var deleted = torneoService.Delete( id );
    if (!deleted) {
        return Results.NotFound();
    }
    return Results.NoContent();
})
.WithName("DeleteTorneo")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();
#endregion

#region MetodosHttpTipoTorneo

app.MapGet("/tipoTorneos/{id}", (int id) =>
{
    TipoTorneoService tipoTorneoService = new TipoTorneoService();
    var tipoToreno = tipoTorneoService.Get(id);

    if (tipoToreno is null)
    {
        return Results.NotFound();
    }

    var dtoResult = new DTOs.TipoTorneo
    {
        Id = tipoToreno.Id,
        Nombre = tipoToreno.Nombre,
        Descripcion = tipoToreno.Descripcion
    };
    return Results.Ok(dtoResult);
})
.WithName("GetTipoTorneo")
.Produces<DTOs.TipoTorneo>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.MapGet("/tipoTorneos", () =>
{
    TipoTorneoService tipoTorneoService = new TipoTorneoService();
    var tipoTorenos = tipoTorneoService.GetAll();

    var dtosResult = tipoTorenos.Select(tipoTorneo => new DTOs.TipoTorneo
    {
        Id = tipoTorneo.Id,
        Nombre = tipoTorneo.Nombre,
        Descripcion = tipoTorneo.Descripcion
    }).ToList();
    return Results.Ok(dtosResult);
})
.WithName("GetAllTipoTorneo")
.Produces<DTOs.TipoTorneo>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.MapPost("/tipoTorneos", (DTOs.TipoTorneo dto) =>
{
    try
    {
        TipoTorneoService tipoTorneoService = new TipoTorneoService();
        TipoTorneo tipoTorneo = new TipoTorneo(dto.Id, dto.Nombre, dto.Descripcion);
        tipoTorneoService.Add(tipoTorneo);

        var dtoResult = new DTOs.TipoTorneo
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
.Produces<DTOs.TipoTorneo>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.MapPut("/tipoTorneos/{id}", (int id, DTOs.TipoTorneo dto) =>
{
    try
    {
        TipoTorneoService tipoTorneoService = new TipoTorneoService();
        TipoTorneo tipoTorneo = new TipoTorneo(dto.Id, dto.Nombre, dto.Descripcion);

        var found = tipoTorneoService.Update(tipoTorneo);
        if (!found)
        {
            return Results.NotFound();
        }

        return Results.NoContent();
    }catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }

} )
.WithName("UpdateTipoTorneo")
.Produces<DTOs.TipoTorneo>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.MapDelete("/tipoTorneos/{id}", (int id) =>
{
    TipoTorneoService tipoTorneoService = new TipoTorneoService();
    var tipoTorneoToDelete = tipoTorneoService.Delete(id);

    if(!tipoTorneoToDelete)
    {
        return Results.NotFound();
    }
    return Results.NoContent();
})
.WithName("DeleteTipoTorneo")
.Produces<DTOs.TipoTorneo>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();
#endregion


app.Run();
