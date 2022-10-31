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

app.Map("/{*catchEverything}", () =>
{
    return Results.NotFound("NOT FOUND! :(");
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run(); 

//TODO: test and debug
//TODO: fix view models