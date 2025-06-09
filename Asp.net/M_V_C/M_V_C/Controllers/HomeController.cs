using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using M_V_C.Models;

namespace M_V_C.Controllers;

public class HomeController : Controller
{
    
    public IActionResult Index()
    {
        HomeModel home = new HomeModel();
        home.Nome= "Igor Felipe Dornelles";
        home.Email= "igor.dornelles94@gmail.com";


        return View(home);
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
