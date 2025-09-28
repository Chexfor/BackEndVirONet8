using FrontEndVirOBlazorAsamblin.Models;
using System.Net.Http.Json;

namespace FrontEndVirOBlazorAsamblin.Services
{
    public class DeporteService
    {
        private readonly HttpClient _http;

        public DeporteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<DeporteDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<DeporteDto>>("api/deportes") ?? new();
        }

        public async Task<DeporteDto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<DeporteDto>($"api/deportes/{id}");
        }

        public async Task<bool> CreateAsync(DeporteDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/deportes", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, DeporteDto dto)
        {
            var response = await _http.PutAsJsonAsync($"api/deportes/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/deportes/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
