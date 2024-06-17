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
         List<Kaempfer?> kaempfer = dbctx.Kaempfer.ToList();
         //Der View übergeben
        return View(kaempfer);
    }

    [HttpPost]
    public IActionResult SaveKaempfer(Kaempfer? kaempfer)
    {
        MyDbContext dbctx = new MyDbContext();
        dbctx.Kaempfer.Add(kaempfer);
        dbctx.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult UpdateKaempfer(Kaempfer? kaempfer)
    {
        MyDbContext dbctx = new MyDbContext();
        dbctx.Kaempfer.Update(kaempfer);
        dbctx.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult New()
    {
        return View();
    }

    public IActionResult Edit(Guid id)
    {
        MyDbContext dbctx = new MyDbContext();
        Kaempfer? kaempfer = dbctx.Kaempfer.FirstOrDefault(b => b != null && b.Kaempferid == id);
        return View(kaempfer);
    }
    public IActionResult Delete(Guid id)
    {
        return RedirectToAction("Index");
    }
}