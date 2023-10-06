using Application.Interfaces;
using Application.Mappings;
using Application.Service;
using Domain.Interfaces.Query;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Infrastructure.Queries;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//user
builder.Services.AddScoped<IUserQuery,UserQuery>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

//brands & series
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IBrandQuery, BrandQuery>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ISeriesService, SeriesService>();
builder.Services.AddScoped<ISeriesQuery, SeriesQuery>();
builder.Services.AddScoped<ISeriesRepository, SeriesRepository>();

#region Components

#endregion

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton(AutoMapperConfig.Initialize());
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=.\\SQLEXPRESS;Initial " +
            "Catalog=PCBuilder;Integrated " +
            "Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True"));
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
