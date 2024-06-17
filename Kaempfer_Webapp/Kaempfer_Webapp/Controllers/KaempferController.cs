using Kaempfer_Webapp.Context;
using Kaempfer_Webapp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    [HttpPost]
    public IActionResult UpdateKaempfer(Kaempfer? kaempfer)
    {
        if (kaempfer == null)
        {
            return BadRequest();
        }

        MyDbContext dbctx = new MyDbContext();
        var existingKaempfer = dbctx.Kaempfer.FirstOrDefault(k => k.Kaempferid == kaempfer.Kaempferid);

        if (existingKaempfer != null)
        {
            existingKaempfer.Vorname = kaempfer.Vorname;
            existingKaempfer.Nachname = kaempfer.Nachname;
            existingKaempfer.Geburtsdatum = kaempfer.Geburtsdatum;
            dbctx.SaveChanges();
        }

        return RedirectToAction("Index");
    }
    public IActionResult New()
    {
        return View();
    }

    public IActionResult Edit(Guid id)
    {
        MyDbContext dbctx = new MyDbContext();
        Kaempfer kaempfer = dbctx.Kaempfer.FirstOrDefault(b => b.Kaempferid == id);
        return View(kaempfer);
    }
    public IActionResult Delete(Guid id)
    {
        MyDbContext dbctx = new MyDbContext();
        Kaempfer kaempferToDelete = dbctx.Kaempfer.FirstOrDefault(b => b.Kaempferid == id);
        dbctx.Kaempfer.Remove(kaempferToDelete);
        dbctx.SaveChanges();
        return RedirectToAction("Index");
    }
}