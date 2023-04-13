using System.Diagnostics;
using FoodProcessorShop.Context;
using Microsoft.AspNetCore.Mvc;
using FoodProcessorShop.Models;

namespace FoodProcessorShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.FoodProcessors.ToList());
    }
    public IActionResult Orders()
    {
        return View(_context.Orders.ToList());
    }
    
    [HttpGet]
    public IActionResult Buy(Guid? id)
    {
        if (id == null) return RedirectToAction("Index");
        ViewBag.FoodProcessorId = id;
        return View();
    }
    [HttpPost]
    public string Buy(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
        return "Спасибо, " + order.User + ", за покупку!";
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}