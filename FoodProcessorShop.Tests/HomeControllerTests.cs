using System.Diagnostics;
using FoodProcessorShop.Controllers;
using FoodProcessorShop.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FoodProcessorShop.Tests;

public class HomeControllerTests
{
    [Fact]
    public void Index()
    {
        //Arrange
        var mock = new Mock<IRepository>();
        mock.Setup(repo => repo.FoodProcessors).Returns(GetTestFoodProcessors);
        var controller = new HomeController(mock.Object);
        //Act
        var result = controller.Index();
        //Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(GetTestFoodProcessors().Count, 
            (viewResult.Model as IEnumerable<FoodProcessor>).Count());
    }

    [Fact]
    public void Orders()
    {
        var mock = new Mock<IRepository>();
        mock.Setup(repo => repo.Orders).Returns(GetTestOrders);
        var controller = new HomeController(mock.Object);
        
        var result = controller.Orders();
        
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(GetTestFoodProcessors().Count,
            (viewResult.Model as IEnumerable<Order>).Count());
    }

    [Fact]
    public void HttpGetBuy()
    {
        var mock = new Mock<IRepository>();
        mock.Setup(repo => repo.Orders).Returns(GetTestOrders);
        var controller = new HomeController(mock.Object);

        var guid = Guid.NewGuid();
        var result = controller.Buy(guid);
        
        Assert.Equal(guid ,(result as ViewResult).ViewData["Id"]);
        Assert.IsType<ViewResult>(result);
        //Assert.IsNotType<RedirectToActionResult>(result);
    }
    
    [Fact]
    public void HttpPostBuy()
    {
        var mock = new Mock<IRepository>();
        mock.Setup(repo => repo.Orders).Returns(GetTestOrders);
        var controller = new HomeController(mock.Object);
        
        var result = controller.Buy(mock.Object.Orders.First());

        Assert.Contains("Спасибо", result);
    }

    [Fact]
    public void Error()
    {
        var mock = new Mock<IRepository>();
        mock.Setup(repo => repo.Orders).Returns(GetTestOrders);
        var controller = new HomeController(mock.Object);
        var result = controller.Error();
        Assert.IsType<ViewResult>(result);
    }

    private List<Order> GetTestOrders()
    {
        var firstFoodProcessor = GetTestFoodProcessors().First();
        var secondFoodProcessor = GetTestFoodProcessors().Skip(1).First();
        var orders = new List<Order>()
        {
            new Order()
            {
                FoodProcessor = firstFoodProcessor,
                Address = "Северный Венец 32",
                isUrgently = false,
                User = "Nikita Butin",
                ContactPhone = "+7(902)128-74-33",
                OrderId = Guid.NewGuid(),
                FoodProcessorId = firstFoodProcessor.Id
            },
            new Order()
            {
                FoodProcessor = secondFoodProcessor,
                Address = "Гончарова 32",
                isUrgently = true,
                User = "Ivan Efimov",
                ContactPhone = "+7(905)094-15-57",
                OrderId = Guid.NewGuid(),
                FoodProcessorId = secondFoodProcessor.Id
            }
        };
        return orders;
    }
    private List<FoodProcessor> GetTestFoodProcessors()
    {
        var foodProcessors = new List<FoodProcessor>()
        {
            new FoodProcessor()
            {
                Id = Guid.NewGuid(),
                Company = "SunnySoft",
                Name = "Mega-2000",
                Price = 1337,
                BowlCapacity = 0.5,
                BowlMaterial = "Steel",
                SpeedsCount = 8
            },
            new FoodProcessor()
            {
                Id = Guid.NewGuid(),
                Company = "Sumsung",
                Name = "UltraPivo",
                Price = 2000,
                BowlCapacity = 0.6,
                BowlMaterial = "Plastic",
                SpeedsCount = 2
            }
        };
        return foodProcessors;
    }
}