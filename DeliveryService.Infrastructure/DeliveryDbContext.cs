using Microsoft.EntityFrameworkCore;
using DeliveryService.Domain.Entities;
using System.Collections.Generic;

namespace DeliveryService.Infrastructure;

public class DeliveryDbContext : DbContext
{
    public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Delivery> Deliveries => Set<Delivery>();
}
