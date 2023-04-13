using FoodProcessorShop.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodProcessorShop.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<FoodProcessor> FoodProcessors { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FoodProcessor>()
            .HasData(
                new FoodProcessor
                {
                    Id = Guid.NewGuid(),
                    Company = "Aresa",
                    Name = "AR-1704",
                    Price = 2399,
                    SpeedsCount = 1,
                    BowlCapacity = 0.35,
                    BowlMaterial = "Пластик"
                },
                new FoodProcessor
                {
                    Id = Guid.NewGuid(),
                    Company = "Endever",
                    Name = "Sigma-21S",
                    Price = 6099,
                    SpeedsCount = 6,
                    BowlCapacity = 4,
                    BowlMaterial = "Металл"
                });
        base.OnModelCreating(modelBuilder);
    }
}