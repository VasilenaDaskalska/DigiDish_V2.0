using System.Net.Http.Json;
using DigiDish.BusinessModels.ShoppingLists;
using DigiDish.HttpRepository.Contracts;

namespace DigiDish.HttpRepository
{
    public class ShoppingListHttpRepository : IShoppingListHttpRepository
    {
        private readonly HttpClient _httpClient;

        public ShoppingListHttpRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<ShoppingListBiz> CreateAsync(ShoppingListBiz model)
        {
            var response = await this._httpClient.PostAsJsonAsync("api/shopping-list", model);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ShoppingListBiz>();
        }

        public async Task<IEnumerable<ShoppingListBiz>> GetAllAsync()
            => await this._httpClient.GetFromJsonAsync<IEnumerable<ShoppingListBiz>>("api/shopping-list");

        public async Task<ShoppingListBiz?> GetByIdAsync(long id)
            => await this._httpClient.GetFromJsonAsync<ShoppingListBiz>($"api/shopping-list/{id}");

        public async Task UpdateAsync(ShoppingListBiz shoppingList)
        {
            var response = await this._httpClient.PutAsJsonAsync($"api/shopping-list", shoppingList);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var response = await this._httpClient.DeleteAsync($"api/shopping-list/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
