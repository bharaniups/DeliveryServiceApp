public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ApiKeyOptions _options;

    public ApiKeyMiddleware(RequestDelegate next, ApiKeyOptions options)
    {
        _next = next;
        _options = options;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("x-api-key", out var providedKey) ||
            _options.ApiKey != providedKey)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized: Invalid API Key");
            return;
        }

        await _next(context);
    }
}

public class ApiKeyOptions
{
    public string ApiKey { get; set; } = string.Empty;
}
