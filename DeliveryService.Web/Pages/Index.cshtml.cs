using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public IndexModel(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClient = httpClientFactory.CreateClient();
        _configuration = configuration;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var apiUrl = _configuration["ApiSettings:BaseUrl"]; // example: https://deliveryservice-api.azurewebsites.net
        var apiKey = _configuration["ApiSettings:ApiKey"];  // example: ApiKey MY_SECRET_KEY

        var request = new HttpRequestMessage(HttpMethod.Get, $"{apiUrl}/api/deliveries");
        request.Headers.Add("Authorization", apiKey); // This must match what API expects

        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            // Deserialize & use data
        }
        else
        {
            ViewData["Error"] = $"API call failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
        }

        return Page();
    }
}
