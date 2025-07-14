using DeliveryService.Application.Interfaces;
using DeliveryService.Infrastructure;
using DeliveryService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// 👉 Configure EF Core with SQL Server
builder.Services.AddDbContext<DeliveryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 👉 Register Repository
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();

// 👉 API Key Config
var apiKey = builder.Configuration["ApiSettings:ApiKey"] ?? "default-key";
builder.Services.AddSingleton(new ApiKeyOptions { ApiKey = apiKey });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 👉 Use API Key Middleware
app.UseMiddleware<ApiKeyMiddleware>();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
