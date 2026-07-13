using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Ticketing.Web.Components;
using BlazorTicketingApp.Services.Contracts;
using BlazorTicketingApp.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// DAFTARKAN SERVICES (Sebelum builder.Build)

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Daftarkan HttpClient agar AuthService bisa memanggil API Backend Anda
// Ganti port 7198 dengan port API Backend Anda yang sebenarnya
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7198/") });

// Daftarkan service untuk Autentikasi dan LocalStorage
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();

// BUILD APLIKASI
var app = builder.Build();

// KONFIGURASI MIDDLEWARE (Pipeline)

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();