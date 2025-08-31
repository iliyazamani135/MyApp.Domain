using Microsoft.EntityFrameworkCore;
using MyApp.Application.Interfaces;
using MyApp.Application.Services;
using Serilog;
using MyApp.Infrastructure.Persistence;
using MyApp.Infrastructure.Seed;
using MyApp.Infrastructure.Repositories;
using MyApp.Application.Mappings;
using FluentValidation.AspNetCore;
using MyApp.Application.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MyAppAPI.Settings;
using Microsoft.OpenApi.Models;
using MyApp.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// تنظیمات Logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MyApp API",
        Version = "v1",
        Description = "A simple clean architecture-based API for apartment reservation.",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your@email.com"
        }
    });
});
// ثبت DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MyAppDb")); // برای محیط تست/توسعه
                                             // برای تولید: options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

// ثبت AutoMapper (یکبار و با اشاره به Assembly مپینگ‌ها)
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// ثبت Repositoryها
builder.Services.AddScoped<IApartmentRepository, ApartmentRepository>();

builder.Services.AddScoped<IUserRepository, ApartmentService>();

// ثبت سرویس‌ها با وابستگی‌هایشان


builder.Services.AddScoped<IReservationRepository, ReservationService>();

// FluentValidation
builder.Services.AddFluentValidation(fv =>
    fv.RegisterValidatorsFromAssemblyContaining<ReservationDtoValidator>());

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyApp API V1");
       // c.RoutePrefix = string.Empty; // Swagger در root باز میشه
    });
}//System.Reflection.TargetInvocationException: 'Exception has been thrown by the target of an invocation.'


app.UseHttpsRedirection();

// Middlewareهای سفارشی
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
    
app.Run();