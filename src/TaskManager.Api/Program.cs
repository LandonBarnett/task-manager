using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using Scalar.AspNetCore;
using System.Net.WebSockets;
using TaskManager.Api.Data;
using TaskManager.Api.Models;
using TaskManager.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    }).AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();  //keeps your OpenAPI JSON
    app.MapScalarApiReference(); // adds Scalar UI at /scalar
}

app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast =  Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");

var tasks = app.MapGroup("/api/tasks").RequireAuthorization();

tasks.MapGet("/", async (ApplicationDbContext db, ClaimsPrincipal user) =>
{
    var uid = user.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
    var list = await db.TaskItems
        .Where(t => !t.IsDeleted && t.OwnerId == uid)
        .OrderBy(t => t.DueDate)
        .ToListAsync();
    return Results.Ok(list.Select(t => new TaskDto
    {
        /* map fields */
    }));
});

tasks.MapPost("/", async (CreateTaskDto dto, ApplicationDbContext db, ClaimsPrincipal user) =>
{
    var uid = user.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
    var t = new TaskItem
    {
        Title = dto.Title,
        Description = dto.Description,
        DueDate = dto.DueDate,
        OwnerId = uid
    };
    db.TaskItems.Add(t);
    await db.SaveChangesAsync();
    return Results.Created($"/api/tasks/{t.Id}", t);
});

tasks.MapPut("/{id:int}", async (int id, CreateTaskDto dto, ApplicationDbContext db, ClaimsPrincipal user) =>
{
    var uid = user.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
    var t = await db.TaskItems.FirstOrDefaultAsync(x => x.Id == id && x.OwnerId == uid);
    if (t is null) return Results.NotFound();
    t.Title = dto.Title;
    t.Description = dto.Description;
    t.DueDate = dto.DueDate;
    t.UpdatedAt = DateTime.UtcNow;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

tasks.MapDelete("/{id:int}", async (int id, ApplicationDbContext db, ClaimsPrincipal user) =>
{
    var uid = user.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
    var t = await db.TaskItems.FirstOrDefaultAsync(x => x.Id == id && x.OwnerId == uid);
    if (t is null) return Results.NotFound();
    t.IsDeleted = true;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
