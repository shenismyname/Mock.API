using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Mock.API.Services;
using Mock.API.Services.Interfaces;
using Mock.Domain.Interface;
using Mock.Repository.Context;
using Mock.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MockDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MockDbConnection"))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IVideoGameRepository, VideoGameRepository>();
builder.Services.AddTransient<IPublisherRepository, PublisherRepository>();
builder.Services.AddTransient<IGenreRepository, GenreRepository>();
builder.Services.AddTransient<IVideoGameService, VideoGameService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{    
    app.UseSwagger();
    app.UseSwaggerUI(); // optional config: c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
}

app.UseAuthorization();

app.MapControllers();

app.Run();
