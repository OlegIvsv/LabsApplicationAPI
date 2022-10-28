using LabsApplicationAPI.Interfaces;
using LabsApplicationAPI.Services;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using LabsApplication.UnitOfWork.Interfaces;
using LabsApplication.UnitOfWork.Repositories;
using AutoMapper;
using LabsApplicationAPI.Mapping;
using LabsApplication.AdoNet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency injection
string connectionString = "Server=DESKTOP-9CVRRHV;Database=LabsApplicationDb;Trusted_Connection=True;Encrypt=False;";
builder.Services.AddTransient<IUnitOfWork, AdoUnitOfWork>(p => new(connectionString));
builder.Services.AddTransient<IProductService, ProductService>(p => new(p.GetService<IUnitOfWork>()));

// Automapper configuration to convert ViewModels to DTOs
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
