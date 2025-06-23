using DigiDish.Entities;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace DigiDish_V2.Client.Services
{
    public class UserState
    {
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigationManager;
        private User? _currentUser;

        public event Action? OnUserChanged;

        public UserState(ILocalStorageService localStorage, NavigationManager navigationManager)
        {
            _localStorage = localStorage;
            _navigationManager = navigationManager;
        }

        public User? CurrentUser => _currentUser;

        public async Task InitializeAsync()
        {
            try
            {
                var userJson = await _localStorage.GetItemAsync<string>("user");
                if (!string.IsNullOrEmpty(userJson))
                {
                    _currentUser = JsonSerializer.Deserialize<User>(userJson);
                    OnUserChanged?.Invoke();
                }
            }
            catch
            {
                _currentUser = null;
            }
        }

        public async Task SetUserAsync(User? user)
        {
            _currentUser = user;
            if (user != null)
            {
                await _localStorage.SetItemAsync("user", JsonSerializer.Serialize(user));
            }
            else
            {
                await _localStorage.RemoveItemAsync("user");
            }
            OnUserChanged?.Invoke();
        }

        public async Task LogoutAsync()
        {
            await SetUserAsync(null);
            _navigationManager.NavigateTo("/login");
        }

        public bool IsAuthenticated => _currentUser != null;
    }
} 