using Microsoft.EntityFrameworkCore;
using MyApp.Application.Interfaces;
using MyApp.Application.Services;
using AutoMapper;
using Serilog;
using MyApp.Infrastructure.Persistence;
using MyApp.Infrastructure.Seed;
using Microsoft.Extensions.DependencyInjection;

//using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Persistence;
using MyApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using MyApp.Application.Mappings;
using FluentValidation.AspNetCore;
using MyApp.Application.Validators;
using MyApp.Infrastructure.Seed;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MyAppAPI.Settings;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MyAppDb")); // ?? ????? ???? SQL Server

// Register Repository
builder.Services.AddScoped<IApartmentRepository, ApartmentRepository>(); // ???? ?? ??????? ???? ?? ?? ?? ?? ?? ????? ???? ?????? ? ??? ??? ???? ??????? ? ???? ??? ???? 
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

builder.Services.AddScoped<IReservationService, ReservationService>();

app.UseMiddleware<MyAppAPI.Middlewares.ExceptionHandlingMiddleware>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ReservationDtoValidator>());

app.UseMiddleware<MyAppAPI.Middlewares.ExceptionHandlingMiddleware>();


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// جایگزین Logger پیش‌فرض با Serilog
builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ReservationDtoValidator>());
builder.Services.AddAutoMapper(typeof(MappingProfile));
// سرویس‌های دیگرت...

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    SeedData.Initialize(context);
}
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
app.UseAuthentication();
app.UseAuthorization();

app.Run();


// ?? ??? ??? ?? ?????? ??????? ???? ???????? ????? ???? ?? ?? ?????? ?? ?? ???? ?????? ? ????? ?????

// addsinglation ??? ????? ????? ???? ? ?? ??? ??? ???????? ?????? ??? ??? ??? ??????? ???? 

// addscoped ???? ?? ?????? ?? ?? ?? ?? ?? ??????? ???? ?????? ???? ????????? ???? 

//addtransient ????? ?? ??????? ?? ?? ????? ???? ?????? 