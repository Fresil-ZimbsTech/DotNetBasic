using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Models;

namespace ViewModel.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Student> students = new List<Student>
       {
           new Student{Id=1, Name="Ali" , Gender="Male", Standard=10},
           new Student{Id=2, Name="Fresil" , Gender="Male", Standard=11},
           new Student{Id=3, Name="Diya" , Gender="Female", Standard=9},
           new Student{Id=4, Name="Karan" , Gender="Male", Standard=12}
           };
        List<Teacher> teacher = new List<Teacher>
       {
           new Teacher{Id=1, Name="sir Ali" ,Qualification="M.TECH", Salary=450000},
           new Teacher{Id=2, Name="sir Fresil" ,Qualification="MCA", Salary=550000},
           new Teacher{Id=3, Name="sir Diya" , Qualification="BCA", Salary=350000},
           new Teacher{Id=4, Name="sir Karan" ,Qualification="B.ED", Salary=250000}
           };

        SchoolViewModel svm = new SchoolViewModel()
        {
            myStudent = students,
            myTeacher = teacher
        };
        return View(svm);
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
