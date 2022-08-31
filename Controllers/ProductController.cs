using Microsoft.AspNetCore.Mvc;

namespace LecControllers.Controllers;

public class ProductController : Controller
{
    public IActionResult Details(string id)
    {
        return View(id);
    }
}

