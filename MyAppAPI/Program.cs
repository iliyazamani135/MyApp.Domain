
// ?? ??? ??? ?? ?????? ??????? ???? ???????? ????? ???? ?? ?? ?????? ?? ?? ???? ?????? ? ????? ?????

// addsinglation ??? ????? ????? ???? ? ?? ??? ??? ???????? ?????? ??? ??? ??? ??????? ???? 

// addscoped ???? ?? ?????? ?? ?? ?? ?? ?? ??????? ???? ?????? ???? ????????? ???? 

//addtransient ????? ?? ??????? ?? ?? ????? ???? ?????? 

using Microsoft.EntityFrameworkCore;
using MyApp.Application.Interfaces;
using MyApp.Application.Services;
using AutoMapper;
using Serilog;
using MyApp.Infrastructure.Persistence;
using MyApp.Infrastructure.Seed;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Infrastructure.Repositories;
using MyApp.Application.Mappings;
using FluentValidation.AspNetCore;
using MyApp.Application.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MyAppAPI.Settings;
using MyApp.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// تنظیمات Logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// ثبت سرویس‌ها
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ApartmentService>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MyAppDb")); // یا SQL Server

builder.Services.AddScoped<IApartmentRepository, ApartmentRepository>();
builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ReservationDtoValidator>());

// پیکربندی JWT
var jwtSettings = new JwtSettings();
builder.Configuration.Bind("JwtSettings", jwtSettings);
builder.Services.AddSingleton(jwtSettings);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtSettings.Issuer,

        ValidateAudience = true,
        ValidAudience = jwtSettings.Audience,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),

        ValidateLifetime = true
    };
});

var app = builder.Build();

// اجرای Middlewareها و تنظیمات درخواست‌ها
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<MyAppAPI.Middlewares.ExceptionHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// اجرای Seed دیتا
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    SeedData.Initialize(context);
}
// Program.cs



app.Run();
