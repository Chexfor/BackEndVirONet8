namespace FrontEndVirOBlazorAsamblin.Services
{
    using System.Net.Http.Json;
    using FrontEndVirOBlazorAsamblin.Models;

    public class PersonaService
    {
        private readonly HttpClient _http;

        public PersonaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<PersonaDto>> GetAllAsync()
            => await _http.GetFromJsonAsync<List<PersonaDto>>("api/personas") ?? new();

        public async Task<PersonaDto?> GetByIdAsync(int id)
            => await _http.GetFromJsonAsync<PersonaDto>($"api/personas/{id}");

        public async Task<PersonaDto?> CreateAndReturnDtoAsync(PersonaCreateDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/personas", dto);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<PersonaDto>();
        }

        public async Task<bool> UpdateAsync(int id, PersonaCreateDto persona)
        {
            var response = await _http.PutAsJsonAsync($"api/personas/{id}", persona);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/personas/{id}");
            return response.IsSuccessStatusCode;
        }

        // Opcional: asignar deporte
        public async Task<bool> AsignarDeporte(int personaId, List<int> deportesIds)
        {
            var dto = new { deportesIds }; // 👈 genera el JSON correcto
            var response = await _http.PostAsJsonAsync($"api/personas/{personaId}/deportes", dto);
            return response.IsSuccessStatusCode;
        }
        // Opcional: quitar deporte
        public async Task<bool> QuitarDeporte(int personaId, int deporteId)
        {
            var response = await _http.DeleteAsync($"api/personas/{personaId}/deportes/{deporteId}");
            return response.IsSuccessStatusCode;
        }
    }
}
