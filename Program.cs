using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using SH.Components;
using Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Serilog;
using System.IO;

//using SH.Data;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add Entity Framework Core services
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleSH"),
    providerOptions => providerOptions.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion19)));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAutoMapper(typeof(Features.Client.ClientProfile));
builder.Services.AddScoped<Features.Client.ClientService>();

// Ensure ./logs directory exists
var logDir = Path.Combine(Directory.GetCurrentDirectory(), "logs");
if (!Directory.Exists(logDir))
{
    Directory.CreateDirectory(logDir);
}

// Configure Serilog from appsettings
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();
    
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
