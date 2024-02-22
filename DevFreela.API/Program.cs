using DevFreela.API.Interfaces;
using DevFreela.API.Models;
using DevFreela.Application.Commands.Projects.CreateProject;
using System.Text.Json.Serialization;
using DevFreela.Infrastructure;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(o =>
{
    //o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);

//builder.Services.AddScoped<IExampleClass, ExampleClass>(e => new ExampleClass { Title = "Initial Stage" });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //builder.Services.Configure<OpeningTimeSection>(builder.Configuration.GetSection("OpeningTime"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
