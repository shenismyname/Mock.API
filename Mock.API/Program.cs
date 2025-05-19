using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Mock.API.Middleware;
using Mock.API.Services;
using Mock.API.Services.Interfaces;
using Mock.Application.Mappers;
using Mock.Application.Services;
using Mock.Application.Services.Interfaces;
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

builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddScoped<IVideoGameRepository, VideoGameRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddTransient<IGenreServices, GenreService>();
builder.Services.AddTransient<IPublisherService, PublisherService>();
builder.Services.AddTransient<IVideoGameService, VideoGameService>();
builder.Services.AddAutoMapper(typeof(GetGenreDtoGenreMapper));
builder.Services.AddAutoMapper(typeof(CreateGenreDtoGenreMapper));
builder.Services.AddAutoMapper(typeof(GetPublisherDtoPublisherMapper));
builder.Services.AddAutoMapper(typeof(CreatePublisherDtoPublisherMapper));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{    
    app.UseSwagger();
    app.UseSwaggerUI(); // optional config: c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
}

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
