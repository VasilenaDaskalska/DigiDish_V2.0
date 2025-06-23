using System.Net.Http.Json;
using DigiDish.BusinessModels.Recipes;
using DigiDish.HttpRepository.Contracts;

namespace DigiDish.HttpRepository
{
    public class RecipeHttpRepository : IRecipeHttpRepository
    {
        private readonly HttpClient _httpClient;

        public RecipeHttpRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<RecipeBiz>> GetAllAsync()
            => await this._httpClient.GetFromJsonAsync<IEnumerable<RecipeBiz>>("api/recipe");

        public async Task<RecipeBiz?> GetByIdAsync(long id)
            => await this._httpClient.GetFromJsonAsync<RecipeBiz>($"api/recipe/{id}");

        public async Task<RecipeBiz> CreateAsync(RecipeBiz model)
        {
            var response = await this._httpClient.PostAsJsonAsync("api/recipe", model);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<RecipeBiz>();
        }

        public async Task UpdateAsync(RecipeBiz recipe)
        {
            var response = await this._httpClient.PutAsJsonAsync($"api/recipe", recipe);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var response = await this._httpClient.DeleteAsync($"api/recipe/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
