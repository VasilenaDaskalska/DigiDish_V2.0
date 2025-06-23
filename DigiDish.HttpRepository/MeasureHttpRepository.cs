using System.Net;
using System.Net.Http.Json;
using DigiDish.BusinessModels.Measures;
using DigiDish.HttpRepository.Contracts;

namespace DigiDish.HttpRepository
{
    public class MeasureHttpRepository : IMeasureHttpRepository
    {
        private readonly HttpClient _httpClient;

        public MeasureHttpRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<MeasureBiz> CreateAsync(MeasureBiz model)
        {
            var response = await this._httpClient.PostAsJsonAsync("api/measures", model);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MeasureBiz>();
        }

        public async Task<IEnumerable<MeasureBiz>> GetAllAsync()
        {
            try
            {
                var response = await this._httpClient.GetFromJsonAsync<IEnumerable<MeasureBiz>>("api/measures");
                return response;
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    // Handle 404 specifically
                    Console.WriteLine("Error: Endpoint not found.");
                }
                else
                {
                    // Handle other types of exceptions
                    Console.WriteLine($"Request failed: {ex.Message}");
                }
                return Enumerable.Empty<MeasureBiz>();  // Return an empty list as fallback
            }
        }

        public async Task<MeasureBiz?> GetByIdAsync(long id)
            => await this._httpClient.GetFromJsonAsync<MeasureBiz>($"api/measures/{id}");

        public async Task UpdateAsync(MeasureBiz measure)
        {
            var response = await this._httpClient.PutAsJsonAsync($"api/measures", measure);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var response = await this._httpClient.DeleteAsync($"api/measures/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
