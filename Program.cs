using Microsoft.EntityFrameworkCore;
using RecordShop.Data;
using RecordShop.Repository;
using RecordShop.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Create and KEEP the connection open (important for in-memory SQLite)

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseInMemoryDatabase("TestDb"));

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddScoped<IAlbumModel, AlbumModel>();
builder.Services.AddScoped<IAlbumService, AlbumService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
