using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Ticketing.API.Data;
using Ticketing.API.Interfaces;
using Ticketing.API.Services;
using Ticketing.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 1. REGISTRASI CONTROLLERS & DB CONTEXT
// ==========================================
var configuredConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? builder.Configuration["ConnectionStrings:DefaultConnection"]
    ?? builder.Configuration["Supabase:ConnectionString"];

var connectionString = configuredConnectionString;

if (string.IsNullOrWhiteSpace(connectionString))
{
    var host = builder.Configuration["Supabase:Host"];
    var port = builder.Configuration["Supabase:Port"] ?? "5432";
    var database = builder.Configuration["Supabase:Database"] ?? "postgres";
    var username = builder.Configuration["Supabase:Username"] ?? "postgres";
    var password = builder.Configuration["Supabase:Password"];
    var sslMode = builder.Configuration["Supabase:SslMode"] ?? "Require";

    connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password};Ssl Mode={sslMode};Trust Server Certificate=true;";
}
else if (connectionString.StartsWith("postgresql://", StringComparison.OrdinalIgnoreCase))
{
    var uri = new Uri(connectionString);
    var path = uri.AbsolutePath.Trim('/');
    var userInfo = uri.UserInfo.Split(':', 2);
    var username = Uri.UnescapeDataString(userInfo[0]);
    var password = userInfo.Length > 1 ? Uri.UnescapeDataString(userInfo[1]) : string.Empty;

    connectionString = $"Host={uri.Host};Port={uri.Port};Database={path};Username={username};Password={password};Ssl Mode=Require;Trust Server Certificate=true;";
}

builder.Services.AddDbContext<TicketingDbContext>(options =>
    options.UseNpgsql(connectionString, npgsqlOptions =>
    {
        npgsqlOptions.CommandTimeout(120);
        npgsqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(10), null);
    }));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

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
    options.MapInboundClaims = false; // Memastikan .NET tidak mengubah nama claim

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
        ValidAudience = jwtSettings.GetValue<string>("Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),

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
builder.Services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
builder.Services.AddScoped<ITicketTypeService, TicketTypeService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ICheckInRepository, CheckInRepository>();
builder.Services.AddScoped<ICheckInService, CheckInService>();
builder.Services.AddScoped<IRefundRepository, RefundRepository>();
builder.Services.AddScoped<IRefundService, RefundService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<IDashboardService, DashboardService>();

var app = builder.Build();

// ==========================================
// 3. HTTP REQUEST PIPELINE (MIDDLEWARE)
// ==========================================
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

// Urutan Middleware Wajib Seperti Ini
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => Results.Ok(new { Message = "Ticketing.API is running smoothly" }));

app.Run();