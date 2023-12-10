using Application.Interfaces;
using Application.Interfaces.Components;
using Application.Mappings;
using Application.Service;
using Application.Service.Components;
using Domain.Entities;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Repository.Components;
using Infrastructure.Common;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//common
builder.Services.AddScoped<ISaveData, SaveData>();

//user
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

//brands & series
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ISeriesService, SeriesService>();
builder.Services.AddScoped<ISeriesRepository, SeriesRepository>();

#region Components

    builder.Services.AddScoped<ICaseRepository, CaseRepository>();
    builder.Services.AddScoped<ICaseService, CaseService>();

    builder.Services.AddScoped<IRamRepository, RamMemoryRepository>();
    builder.Services.AddScoped<IRAMService, RamService>();

    builder.Services.AddScoped<ICPURepository, CPURepository>();
    builder.Services.AddScoped<ICPUService, CPUService>();

    builder.Services.AddScoped<IPowerSupplyService, PowerSupplyService>();
    builder.Services.AddScoped<IPowerSupplyRepository, PowerSupplyRepository>();

    builder.Services.AddScoped<IMotherBoardRepository, MotherboardRepository>();
    builder.Services.AddScoped<IMotherBoardService, MotherboardService>();
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

app.UseCors( options => options.WithOrigins("https://localhost:7214")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
    );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
