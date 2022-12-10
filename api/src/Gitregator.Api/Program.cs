using System;
using Gitregator.Api.Services;
using Gitregator.Github.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);
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

services.AddScoped<IGithubAggregatorService, GithubAggregatorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

await app.RunAsync();
