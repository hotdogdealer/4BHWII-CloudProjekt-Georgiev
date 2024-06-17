using System.Diagnostics;
using Kaempfer_Webapp.Context;
using Microsoft.AspNetCore.Mvc;
using Kaempfer_Webapp.Models;

namespace Kaempfer_Webapp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        MyDbContext dbctx = new MyDbContext();
        int anzahlAnKaempfer = dbctx.Kaempfer.Count();
        
        ViewData["TestData"] = anzahlAnKaempfer.ToString();
        
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