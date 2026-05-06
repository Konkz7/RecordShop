using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RecordShop.Controllers;
using RecordShop.Data;
using RecordShop.Repository;
using RecordShop.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Create and KEEP the connection open (important for in-memory SQLite)

//builder.Services.AddDbContext<MyDbContext>(options =>
//    options.UseInMemoryDatabase("TestDb"));

builder.Services.AddDbContext<MyDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));


builder.Services.AddControllers();
builder.Services.AddScoped<IAlbumModel, AlbumModel>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddHealthChecks()
            .AddCheck<HealthCheck>("health_check",
                failureStatus: HealthStatus.Unhealthy,
                tags: new[] { "file", "products" });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
//    db.Database.EnsureCreated();
//}

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();


app.UseAuthorization();
app.UseHealthChecks("/health");
app.MapControllers();

app.Run();
