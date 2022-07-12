using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cmsMvc.Models;
using Microsoft.AspNetCore.Http;
using cmsMvc.Models.Infra.Auth;

namespace cmsMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Auth]
    public IActionResult Index()
    {   
        string? cookieValue = "";
        this.HttpContext.Request.Cookies.TryGetValue("admin", out cookieValue);
        ViewBag.Role = cookieValue;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [Auth]
    public IActionResult Sair()
    {
        this.HttpContext.Response.Cookies.Delete("admin");
        return RedirectToAction("Index", "Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
