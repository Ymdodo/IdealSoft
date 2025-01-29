using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace IdealSoft
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7275/api/") };//Link da API
        }

        public async Task<List<Cadastro>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("Cadastros");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Cadastro>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Cadastro> CreateAsync(Cadastro cadastro)
        {
            var json = JsonSerializer.Serialize(cadastro);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Cadastros", content);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Cadastro>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Cadastro> UpdateAsync(int id, Cadastro cadastro)
        {
            var json = JsonSerializer.Serialize(cadastro);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"Cadastros/{id}", content);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Cadastro>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Cadastros/{id}");
            response.EnsureSuccessStatusCode();
        }
    }

    public class Cadastro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
    }
}
