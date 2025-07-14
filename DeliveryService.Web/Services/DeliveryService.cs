//using DeliveryService.Domain.Entities;
using DeliveryService.Web.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DeliveryService.Web.Services;

public class DeliveryService
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "SuperSecretDemoKey123"; // match your appsettings.json

    public DeliveryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:5001/api/"); // Update when hosted in Azure
        _httpClient.DefaultRequestHeaders.Add("x-api-key", ApiKey);
    }

    public async Task<List<Delivery>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("deliveries");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Delivery>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? new();
    }
}
