using LecControllers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LecControllers.Controllers;

public class HomeController : Controller
{
    //Fields, properties, methods, action methods
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    #region lecture notes

    public IActionResult Parameter(string id)
    {
        return Content($"Parameter id is {id}.");
    }

    public IActionResult FourSegments(string code, string idNumber)
    {
        return Content($"Code is {code} IDNumber is {idNumber}");
    }

    public IActionResult Bind([Bind(Prefix="id")]string name)
    {
        return Content($"name = {name}");
    } //use query string. .../?name=Dylan
      //also use bind to not use query string

    public IActionResult Details(string enumber)
    {
        return Content($"Enumber = {enumber}");
    }

    //Variable length URL using * in Program.cs route
    public IActionResult Process(string name, string values)
    {
        var result = $"name = {name} values = {values}";
        var itemArray = values.Split('/');
        var itemStr = string.Join(" ", itemArray);
        return Content($"results = {result} item string = {itemStr}");
    }

    #endregion

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
