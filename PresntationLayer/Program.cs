using ApplicationLayer.Contract;
using ApplicationLayer.Mapper;
using ApplicationLayer.Services;
using EContext;
using EContext.Models;
using InfrastructureLayer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using PresntationLayer.Data;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5262/") 
});
//builder.Services.AddServerSideBlazor().AddCircuitOptions(options =>
//{
//    options.DetailedErrors = true;
//    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromSeconds(5);
//});
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
