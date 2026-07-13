using System.Net.Http.Json;
using Blazored.LocalStorage;
using BlazorTicketingApp.Models;
using BlazorTicketingApp.Services.Contracts;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorTicketingApp.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/register", request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AuthResponseDto>();

                if (result?.Token != null)
                {
                    await _localStorage.SetItemAsync("authToken", result.Token);
                    ((CustomAuthStateProvider)_authStateProvider).MarkUserAsAuthenticated(result.Token);
                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", result.Token);
                    result.IsSuccessful = true;
                    return result;
                }

                return new AuthResponseDto
                {
                    IsSuccessful = false,
                    ErrorMessage = result?.ErrorMessage ?? "Registrasi gagal."
                };
            }

            return new AuthResponseDto { IsSuccessful = false, ErrorMessage = "Registrasi gagal." };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AuthResponseDto>();

                if (result?.Token != null)
                {
                    // 1. Simpan token ke local storage
                    await _localStorage.SetItemAsync("authToken", result.Token);

                    // 2. Beritahu aplikasi bahwa user sudah login
                    ((CustomAuthStateProvider)_authStateProvider).MarkUserAsAuthenticated(result.Token);

                    // 3. Masukkan header authorization untuk request API selanjutnya
                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", result.Token);

                    result.IsSuccessful = true;
                    return result;
                }
            }

            return new AuthResponseDto { IsSuccessful = false, ErrorMessage = "Email atau password salah." };
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((CustomAuthStateProvider)_authStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}