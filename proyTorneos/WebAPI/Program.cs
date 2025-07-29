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

app.MapGet("/Usuarios", () =>
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
        UsuarioService alumnoService = new UsuarioService();

        Usuario usuario = new Usuario(dto.Id, dto.Nombre, dto.Apellido, dto.Email, dto.Pais, dto.GamerTag, dto.Rol);

        alumnoService.Add(usuario);

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

app.MapDelete("/usuario/{id}", (int id) =>
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

app.Run();
