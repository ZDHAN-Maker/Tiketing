using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Ticketing.API.Data;
using Ticketing.API.Interfaces;
using Ticketing.API.Services;
using Ticketing.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 1. REGISTRASI CONTROLLERS & SERVICES
// ==========================================
builder.Services.AddControllers();

// Register DbContext menggunakan PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TicketingDbContext>(options =>
    options.UseNpgsql(connectionString));

// ==========================================
// 2. CONFIGURATION JWT AUTHENTICATION
// ==========================================
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings.GetValue<string>("Secret");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    // FIX UTAMA: Hentikan .NET dari mengubah klaim token ("role", "nameid") menjadi URL panjang
    options.MapInboundClaims = false; 

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
        ValidAudience = jwtSettings.GetValue<string>("Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),
        
        // Sesuaikan dengan key yang ada di dalam payload JWT JSON Anda
        RoleClaimType = "role",
        NameClaimType = "unique_name"
    };
});

// Register Dependency Injection Services
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrganizerService, OrganizerService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();
var app = builder.Build();

// ==========================================
// 3. HTTP REQUEST PIPELINE (MIDDLEWARE)
// ==========================================
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

// Urutan middleware tidak boleh tertukar
app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

// Health Check Endpoint
app.MapGet("/", () => Results.Ok(new { Message = "Ticketing.API is running smoothly" }));

app.Run();