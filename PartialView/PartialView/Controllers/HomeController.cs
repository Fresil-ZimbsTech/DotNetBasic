using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PartialView.Models;

namespace PartialView.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Product()
    {
        List<Product> products = new List<Product>()
        {
            new Product { Id = 101, Name = "camera", Price = 450000.00, Description = "Description 1", Image = "~/Images/camera.jpeg" },
            new Product { Id = 102, Name = "headphone", Price = 150000.00, Description = "Description 2", Image = "~/Images/headphone.jpeg" },
            new Product { Id = 103, Name = "watch", Price = 50000.00, Description = "Description 3", Image = "~/Images/watch.jpeg" },
        };
        return View(products);
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
