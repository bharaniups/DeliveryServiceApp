namespace DeliveryService.Web.Models;

public class Delivery
{
    public int Id { get; set; }
    public string OrderNumber { get; set; } = "";
    public string DeliveryBoyName { get; set; } = "";
    public string Status { get; set; } = "";
    public DateTime AssignedDate { get; set; }
}
