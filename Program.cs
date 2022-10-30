using LabsApplicationAPI.Interfaces;
using LabsApplicationAPI.Services;
using System.Web.Mvc;
using LabsApplication.UnitOfWork.Interfaces;
using LabsApplicationAPI.Mapping;
using LabsApplication.AdoNet;

var builder = WebApplication.CreateBuilder(args);

//Dependency injection using extensions from AppConfigServicesExtensions
builder.Services.AddStandardDependencies();
builder.Services.AddUserDefinedDependencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
