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

// Map endpoints
app.MapUsuarioEndpoints();
app.MapJuegoEndpoints();
app.MapTorneoEndpoints();
app.MapTipoTorneoEndpoints();
app.MapInscripcionEndpoints();
app.MapEquipoEndpoints();
app.Run();