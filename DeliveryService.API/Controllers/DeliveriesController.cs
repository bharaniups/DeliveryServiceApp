using DeliveryService.Application.Interfaces;
using DeliveryService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeliveriesController : ControllerBase
{
    private readonly IDeliveryRepository _repo;

    public DeliveriesController(IDeliveryRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<List<Delivery>>> GetAll()
    {
        var deliveries = await _repo.GetAllAsync();
        return Ok(deliveries);
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
    {
        await _repo.UpdateStatusAsync(id, status);
        return NoContent();
    }
}
