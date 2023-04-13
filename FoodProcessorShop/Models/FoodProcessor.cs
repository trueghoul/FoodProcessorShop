namespace FoodProcessorShop.Models;

public class FoodProcessor
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Company { get; set; }
    public int Price { get; set; }
    public string BowlMaterial { get; set; }
    public double BowlCapacity { get; set; }
    public int SpeedsCount { get; set; }
}