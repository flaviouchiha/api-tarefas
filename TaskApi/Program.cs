using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TaskApi.Extensions;
using TaskApi.Models.DTO;
using TaskApi.Validations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiDependencies();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(opt =>
{
    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Task API v1");
    opt.RoutePrefix = string.Empty;
});

app.UseAuthorization();

app.MapControllers();

app.Run();