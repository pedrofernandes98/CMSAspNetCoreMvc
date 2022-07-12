using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cmsMvc.Models;
using Microsoft.AspNetCore.Http;
using cmsMVC.Models.Infra.Database;

namespace cmsMvc.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    private readonly CmsDataContext _context;

    public LoginController(ILogger<LoginController> logger, CmsDataContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {   
        return View();
    }

    [Route("/login/auth")]
    [HttpPost]
    public IActionResult Auth(string email, string senha)
    {
        if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
        {
            ViewBag.MsgError = "Preencha os campos de e-mail e senha";
        }
        else
        {
            var user = _context.Adminastradores.FirstOrDefault(adm => adm.Email == email && 
                                                                      adm.Senha == senha);

            if(user != null)
            {
                this.HttpContext.Response.Cookies.Append("admin", user.Nome, new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddHours(8),
                    HttpOnly = true
                });

                this.HttpContext.Response.Redirect("/");
            }

            ViewBag.MsgError = "Usuário não encontrado. \nE-mail ou senha incorretos";
                                                            
        }

        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
