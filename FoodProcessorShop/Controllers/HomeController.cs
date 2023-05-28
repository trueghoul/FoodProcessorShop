using System.Diagnostics;
using FoodProcessorShop.Context;
using Microsoft.AspNetCore.Mvc;
using FoodProcessorShop.Models;

namespace FoodProcessorShop.Controllers;

public class HomeController : Controller
{
    private readonly IRepository _context;

    public HomeController(IRepository context)
    {
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
    public IActionResult Buy(Guid id)
    {
        if (id == Guid.Empty) return RedirectToAction("Index");
        ViewData["Id"] = id;
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
        try
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        catch (Exception)
        {
            return RedirectToAction("Index");
        }
    }
}