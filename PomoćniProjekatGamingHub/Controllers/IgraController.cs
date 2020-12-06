using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PomoćniProjekatGamingHub.EF;
using PomoćniProjekatGamingHub.EntityModels;
using PomoćniProjekatGamingHub.Models;

namespace PomoćniProjekatGamingHub.Controllers
{
    public class IgraController : Controller
    {
        MojDbContext db = new MojDbContext();
        public IActionResult Prikaz()
        {
            var m = db.Igra.Select(i => new IgraPrikazVM
            {
                Id=i.Id,
                Naziv = i.Naziv,
                DatumIzlaska = i.DatumIzlaska,
                Developer = i.Developer,
                Izdavac = i.Izdavac,
                SlikaLink = i.SlikaLink
            }).ToList();
            return View(m);
        }

        public IActionResult Obrisi(int IgraID)
        {
            Igra igra = db.Igra.Find(IgraID);
            db.Remove(igra);
            db.SaveChanges();
            return Redirect("/Igra/Prikaz");
        }
    }
}
