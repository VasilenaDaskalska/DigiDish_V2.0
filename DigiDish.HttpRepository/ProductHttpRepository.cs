using System.Net.Http.Json;
using DigiDish.BusinessModels.Products;
using DigiDish.HttpRepository.Contracts;

namespace DigiDish.HttpRepository
{
    public class ProductHttpRepository : IProductHttpRepository
    {
        private readonly HttpClient _httpClient;

        public ProductHttpRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<ProductBiz> CreateAsync(ProductBiz model)
        {
            try
            {
                var response = await this._httpClient.PostAsJsonAsync("api/product", model);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<ProductBiz>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProductBiz>> GetAllAsync()
            => await this._httpClient.GetFromJsonAsync<IEnumerable<ProductBiz>>("api/product");

        public async Task<ProductBiz?> GetByIdAsync(long id)
            => await this._httpClient.GetFromJsonAsync<ProductBiz>($"api/product/{id}");

        public async Task UpdateAsync(ProductBiz product)
        {
            var response = await this._httpClient.PutAsJsonAsync($"api/product", product);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var response = await this._httpClient.DeleteAsync($"api/product/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
