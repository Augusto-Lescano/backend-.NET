using Microsoft.AspNetCore.OpenApi;
using System.ComponentModel.DataAnnotations;
using Domain.Model;
using Domain.Services;
using DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebAPI;


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



#region MetodosHttpTipoTorneo

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

app.MapPut("/tipoTorneos/{id}", (int id, DTOs.TipoTorneoDTO dto) =>
{
    try
    {
        TipoTorneoService tipoTorneoService = new TipoTorneoService();
        TipoTorneo tipoTorneo = new TipoTorneo(dto.Id, dto.Nombre, dto.Descripcion);

        var found = tipoTorneoService.Update(dto);
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
.Produces<DTOs.TipoTorneoDTO>(StatusCodes.Status200OK)
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
.Produces<DTOs.TipoTorneoDTO>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();
#endregion

// Map endpoints
app.MapUsuarioEndpoints();
app.MapJuegoEndpoints();
app.MapTorneoEndpoints();
app.Run();