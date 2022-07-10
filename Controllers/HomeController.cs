using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cmsMvc.Models;
using Microsoft.AspNetCore.Http;

namespace cmsMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {   
        string? roleError = "RoleNão encontrada";
        ViewBag.Role = this.HttpContext.Request.Cookies.TryGetValue("admin", out roleError);
        ViewBag.Role = roleError;
        return View();
    }

    public IActionResult Privacy()
    {
        this.HttpContext.Response.Cookies.Append("admin", "adminRole", new CookieOptions(){
            Expires = DateTimeOffset.UtcNow.AddSeconds(10),
            HttpOnly = true
        });

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
