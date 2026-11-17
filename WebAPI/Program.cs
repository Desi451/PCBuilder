using Application.Interfaces;
using Application.Interfaces.Components;
using Application.Mappings;
using Application.Service;
using Application.Service.Components;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Repository.Components;
using Infrastructure.Common;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebAPI.ExceptionHandling;
using WebAPI.Security;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Missing connection string. Set 'ConnectionStrings:DefaultConnection' in the application configuration.");
}

var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];
if (allowedOrigins.Length == 0)
{
    allowedOrigins = ["http://localhost:4200", "https://localhost:7214"];
}

builder.Services.AddControllers();

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddIdentity<User, Role>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";

    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;

    options.Lockout.AllowedForNewUsers = false;
})
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "PCBuilder.Auth";
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.SlidingExpiration = true;

    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    };
    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        return Task.CompletedTask;
    };
});

builder.Services.AddAuthorizationBuilder()
    .SetFallbackPolicy(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build())
    .AddPolicy(Policies.AdminOrAbove, policy => policy.RequireRole(Roles.Admin, Roles.HeadAdmin))
    .AddPolicy(Policies.HeadAdminOnly, policy => policy.RequireRole(Roles.HeadAdmin));

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

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ICurrentUser, CurrentUser>();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors(policy => policy
    .WithOrigins(allowedOrigins)
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
