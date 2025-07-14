using DeliveryService.Application.Interfaces;
using DeliveryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Infrastructure.Repositories
{
    
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly DeliveryDbContext _context;

        public DeliveryRepository(DeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Delivery>> GetAllAsync() =>
            await _context.Deliveries.ToListAsync();

        public async Task<Delivery?> GetByIdAsync(int id) =>
            await _context.Deliveries.FindAsync(id);

        public async Task UpdateStatusAsync(int id, string newStatus)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery == null) return;

            delivery.Status = newStatus;
            await _context.SaveChangesAsync();
        }
    }

}
