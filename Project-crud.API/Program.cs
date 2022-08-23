using Microsoft.OpenApi.Models;
using ProjectCrud.Infrastructure.Dependecies;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc().AddJsonOptions(options =>
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);

builder.Services.AddControllers();
builder.Services.AddLogging();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Projeto CRUD",
        Description = "Api criada para o trabalho de .NET da pós graduação da faculdade UniAlfa",
        Version = "v1"
    });
});

var app = builder.Build();
app.MapControllers();

//app.MapGet("/", () => "Hello World!");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de produto v1");
});

app.Run();
