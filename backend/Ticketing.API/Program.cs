using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using Ticketing.API.Interfaces;
using Ticketing.API.Models;
using Ticketing.API.Services;

var builder = WebApplication.CreateBuilder(args);

// =========================================================================
// 1. SERVICES CONFIGURATION (Dependency Injection)
// =========================================================================
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register Business Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddSingleton<ITokenService, TokenService>();

// =========================================================================
// 2. DATABASE & NPGSQL ENUM CONFIGURATION
// =========================================================================
var connectionString = builder.Configuration.GetConnectionString("TicketingDb");

// Buat Builder DataSource khusus PostgreSQL
var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);

// PETA ENUM: Daftarkan Enum C# Anda ke Enum asli PostgreSQL (Solusi Error Anda)
dataSourceBuilder.MapEnum<RoleScope>("public", "role_scope");
dataSourceBuilder.MapEnum<UserStatus>("public", "user_status");

dataSourceBuilder.EnableUnmappedTypes(); // Fail-safe fallback

var dataSource = dataSourceBuilder.Build();

// Masukkan DataSource yang sudah dikonfigurasi ke EF Core DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(dataSource));

// =========================================================================
// 3. SECURITY & AUTHENTICATION CONFIGURATION (JWT)
// =========================================================================
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = Encoding.UTF8.GetBytes(jwtSettings["Secret"]!);

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
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ClockSkew = TimeSpan.Zero
    };
});

// =========================================================================
// 4. HTTP REQUEST PIPELINE (Middleware Order)
// =========================================================================
var app = builder.Build();

// Urutan Atas: Keamanan Dasar & Pengalihan Trafik
app.UseHttpsRedirection(); 

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Urutan Tengah: Identitas & Hak Akses (Wajib sebelum MapControllers!)
app.UseAuthentication();
app.UseAuthorization();

// Urutan Bawah: Routing & Endpoint Controllers
app.MapControllers();

// Default WeatherForecast Template (Bisa dihapus jika tidak digunakan lagi)
var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

// DTO untuk Template Weather
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}