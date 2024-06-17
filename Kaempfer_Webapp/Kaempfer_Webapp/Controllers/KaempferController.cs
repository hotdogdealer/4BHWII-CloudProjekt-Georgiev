using Kaempfer_Webapp.Context;
using Kaempfer_Webapp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Kaempfer_Webapp.Controllers;

public class KaempferController : Controller
{
    // GET
    public IActionResult Index()
    {
         //Repository erstellen
         MyDbContext dbctx = new MyDbContext();
         
         //Alle Kaempfer Items auslesen
         List<Kaempfer> kaempfer = dbctx.Kaempfer.ToList();
         //Der View übergeben
        return View(kaempfer);
    }
}