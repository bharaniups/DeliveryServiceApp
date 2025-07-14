using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Domain.Entities
{
    public class Delivery
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = default!;
        public string DeliveryBoyName { get; set; } = default!;
        public string Status { get; set; } = "Pending"; // e.g., Picked, Delivered
        public DateTime AssignedDate { get; set; } = DateTime.UtcNow;
    }
}
