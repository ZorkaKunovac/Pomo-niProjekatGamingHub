using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PomoćniProjekatGamingHub.EF;
using PomoćniProjekatGamingHub.EntityModels;
using PomoćniProjekatGamingHub.Models.Konzola;
using PomoćniProjekatGamingHub.Models.Zarn;

namespace PomoćniProjekatGamingHub.Controllers
{
    public class KonzolaController : Controller
    {
        MojDbContext db = new MojDbContext();
        public IActionResult Prikaz()
        {
            var m = db.Konzola.Select(k => new KonzolaPrikazVM
            {
                Id = k.Id,
                Kapacitet = k.Kapacitet,
                Detalji = k.Detalji,
                Naziv = k.Naziv,
            }).ToList();

            return View(m);
        }
        public IActionResult Uredi(int KonzolaID)
        {
            KonzolaUrediVM m;
            if (KonzolaID == 0)
            {
                m = new KonzolaUrediVM() { };
            }
            else
            {
                m = db.Konzola.Where(k => k.Id == KonzolaID)
                .Select(k => new KonzolaUrediVM
                {
                    KonzolaID = k.Id,
                    Naziv = k.Naziv,
                    Detalji = k.Detalji,
                    Kapacitet = k.Kapacitet,
                }).Single();
            }
            return View(m);
        }
        public IActionResult Snimi(KonzolaUrediVM Konzola)
        {
             Konzola konzola;
            if (Konzola.KonzolaID == 0)
            {
                konzola = new Konzola();
                db.Add(konzola);
            }
            else
            {
                konzola = db.Konzola.Find(Konzola.KonzolaID);
            }
            konzola.Naziv = Konzola.Naziv;
            konzola.Kapacitet = Konzola.Kapacitet;
            konzola.Detalji = Konzola.Detalji;

            db.SaveChanges();
            return Redirect("/Konzola/Prikaz");
        }
        public IActionResult Obrisi(int KonzolaID)
        {
             Konzola k = db.Konzola.Find(KonzolaID);
            db.Remove(k);
            db.SaveChanges();
            return Redirect("/Konzola/Prikaz");
        }
        public IActionResult ListaRecenzija()
        {
             List<Recenzija> recenzije = db.Recenzija.ToList();
            ViewData["recenzije"] = recenzije;
            return View("ListaRecenzija");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
