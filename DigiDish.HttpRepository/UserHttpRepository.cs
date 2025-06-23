using System.Net.Http.Json;
using DigiDish.BusinessModels;
using DigiDish.BusinessModels.Users;
using DigiDish.HttpRepository.Contracts;

namespace DigiDish.HttpRepository
{
    public class UserHttpRepository : IUserHttpRepository
    {
        private readonly HttpClient _httpClient;

        public UserHttpRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<UserBiz>> GetAllAsync()
            => await this._httpClient.GetFromJsonAsync<IEnumerable<UserBiz>>("api/user");

        public async Task<UserBiz> GetByIdAsync(long id)
            => await this._httpClient.GetFromJsonAsync<UserBiz>($"api/user/{id}");

        public async Task UpdateAsync(UserBiz user)
        {
            // Ensure required fields are set
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            // Set modification tracking fields
            user.LastModifiedDate = DateTime.UtcNow;
            
            var response = await this._httpClient.PutAsJsonAsync("/api/user/update-user", user);
            
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Update failed: {error}");
            }
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var response = await this._httpClient.DeleteAsync($"api/user/{id}");
            return response.IsSuccessStatusCode;
        }


        // Custom method: Register new user
        public async Task<UserBiz> RegisterUserAsync(UserBiz user)
        {
            var response = await this._httpClient.PostAsJsonAsync("api/user/register", user);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Registration failed: {error}");
            }

            return await response.Content.ReadFromJsonAsync<UserBiz>();
        }

        // Custom method: Update password
        public async Task<bool> ChangePasswordAsync(long userId, string newPassword)
        {
            var payload = new
            {
                UserId = userId,
                NewPassword = newPassword,
            };

            var response = await this._httpClient.PostAsJsonAsync("api/user/update-password", payload);
            return response.IsSuccessStatusCode;
        }

        // Sign in method
        public async Task<SignInResponse> SignInAsync(string username, string password)
        {
            try
            {
                var response = await this._httpClient.PostAsJsonAsync("/api/user/signin", new
                {
                    Username = username,
                    Password = password
                });

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<SignInResponse>();
                    return result;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return new SignInResponse
                    {
                        Success = false,
                        Message = error
                    };
                }
            }
            catch (Exception ex)
            {
                return new SignInResponse
                {
                    Success = false,
                    Message = "An error occurred while signing in."
                };
            }
        }
    }
}
