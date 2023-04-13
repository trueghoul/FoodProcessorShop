namespace FoodProcessorShop.Models;

public class Order
{
    public Guid OrderId { get; set; }
    public string User { get; set; } 
    public string Address { get; set; } 
    public string ContactPhone { get; set; }
    public bool isUrgently { get; set; }
 
    public Guid FoodProcessorId { get; set; } 
    public  FoodProcessor FoodProcessor { get; set; }
}