using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DropDwonList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.AspNetCore.Mvc.Rendering;

namespace DropDwonList.Controllers;

public class HomeController : Controller
{
    public enum Gender
    {
        Male = 0,
        Female = 1
    }
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<SelectListItem> Gender = new()
        {
            new SelectListItem { Value = "Male", Text = "Male" },
            new SelectListItem { Value = "Female", Text = "Female" }
        };
        ViewBag.Gender = Gender; 
        return View();
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
