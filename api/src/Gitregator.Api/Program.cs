using System;
using System.IO;
using System.Reflection;
using Gitregator.Api.Services;
using Gitregator.Github.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("https://192.168.1.66:7259;https://localhost:5000");

builder.Host.UseSerilog();
var services = builder.Services;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .CreateLogger();
services.AddSingleton(Log.Logger);

var gitClient = new GithubClientProvider(Environment.GetEnvironmentVariable("GITHUB_TOKEN")!);
services.AddSingleton(gitClient);

// Add services to the container.

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.ConfigureSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Gitrator API",
        Description = "ASP.NET Core API of the Gitrator project",
        Contact = new OpenApiContact { Name = "ITAM", Url = new Uri("https://github.com/itatmisis") },
        License = new OpenApiLicense
            { Name = "MIT License", Url = new Uri("https://github.com/itatmisis/gitregator/blob/main/LICENSE") }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

services.AddScoped<IGithubAggregatorService, GithubAggregatorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
    x =>
    {
        x.AllowAnyHeader();
        x.AllowAnyMethod();
        x.AllowAnyOrigin();
    });

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync();
