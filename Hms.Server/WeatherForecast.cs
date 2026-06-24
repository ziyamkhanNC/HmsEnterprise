using Hms.Server.Models;
using Microsoft.EntityFrameworkCore; // ◄ Added to recognize database extensions

var builder = WebApplication.CreateBuilder(args);

// 1. REGISTER SERVICES HERE (Before builder.Build)
builder.Services.AddOpenApi();

// 🐘 Move this configuration pool inside the building zone
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("Host=localhost;Database=hms_db;Username=muhammadziyamkhan;Password="));

// 2. BUILD THE APPLICATION
var app = builder.Build();

// 3. CONFIGURE REQUEST PIPELINE (After builder.Build)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
