namespace FoodProcessorShop.Models;

public interface IRepository
{
    public List<FoodProcessor> FoodProcessors { get; set; }
    public List<Order> Orders { get; set; }
    public int SaveChanges();
}