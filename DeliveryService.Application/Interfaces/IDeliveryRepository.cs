using DeliveryService.Domain.Entities;

namespace DeliveryService.Application.Interfaces
{
    public interface IDeliveryRepository
    {
        Task<List<Delivery>> GetAllAsync();
        Task<Delivery?> GetByIdAsync(int id);
        Task UpdateStatusAsync(int id, string newStatus);
    }
}
