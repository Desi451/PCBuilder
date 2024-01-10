using Application.Interfaces;
using Application.Interfaces.Components;
using Application.Mappings;
using Application.Service;
using Application.Service.Components;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Repository.Components;
using Infrastructure.Common;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(1800);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

// Add services to the container.

//common
builder.Services.AddScoped<ISaveData, SaveData>();

//user
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

//brands & series & slots
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ISeriesService, SeriesService>();
builder.Services.AddScoped<ISeriesRepository, SeriesRepository>();
builder.Services.AddScoped<ISlotRepository, SlotRepository>();
builder.Services.AddScoped<ISlotService, SlotService>();

//Computer
builder.Services.AddScoped<IComputerService, ComputerService>();
builder.Services.AddScoped<IComputerRepository, ComputerRepository>();

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

    builder.Services.AddScoped<IGPURepository, GpuRepository>();
    builder.Services.AddScoped<IGpuService, GpuService>();

    builder.Services.AddScoped<ISsdService, SsdService>();
    builder.Services.AddScoped<ISsdRepository, SsdRepository>();

    builder.Services.AddScoped<IHddRepository, HddRepository>();
    builder.Services.AddScoped<IHddService, HddService>();
#endregion

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton(AutoMapperConfig.Initialize());

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=.\\SQLEXPRESS;Initial " +
            "Catalog=PCBuilder;Integrated " +
            "Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();


app.UseSession();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
    .WithOrigins("https://localhost:7214", "http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseAuthentication();

app.UseRouting();
app.MapControllers();

app.Run();
