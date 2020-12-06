using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PomoćniProjekatGamingHub.EF;
using PomoćniProjekatGamingHub.EntityModels;
using PomoćniProjekatGamingHub.Models.Konzola;

namespace PomoćniProjekatGamingHub.Controllers
{
    public class ModeratorController : Controller
    {
        MojDbContext db = new MojDbContext();
        public IActionResult KonzolaPrikaz()
        {
            var m = db.Konzola.Select(k => new KonzolaPrikazVM
            {
                Id = k.Id,
                Kapacitet = k.Kapacitet,
                Detalji = k.Detalji,
                Naziv = k.Naziv,
                Proizvodjac = k.Proizvodjac
            }).ToList();

            return View(m);
        }
        public IActionResult UrediKonzolu(int KonzolaID)
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
                    Proizvodjac = k.Proizvodjac
                }).Single();
            }
            return View(m);
        }
        public IActionResult SnimiKonzolu(KonzolaUrediVM Konzola)
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
            konzola.Proizvodjac = Konzola.Proizvodjac;
            konzola.Kapacitet = Konzola.Kapacitet;
            konzola.Detalji = Konzola.Detalji;

            db.SaveChanges();
            return Redirect("/Moderator/KonzolaPrikaz");
        }
        public IActionResult ObrisiKonzolu(int KonzolaID)
        {
             Konzola k = db.Konzola.Find(KonzolaID);
            db.Remove(k);
            db.SaveChanges();
            return Redirect("/Moderator/KonzolaPrikaz");
        }

        public IActionResult PrikazZarn()
        {
             List<Zarn> zarnovi = db.Zarn.ToList();

            ViewData["zarnovi"] = zarnovi;
            return View("PrikazZarn");
        }
        public IActionResult SnimiZarn(int ZarnID, string Naziv, string Opis)
        {
             Zarn zarn;
            if (ZarnID == 0)
            {
                zarn = new Zarn();
                db.Add(zarn);
            }
            else
            {
                zarn = db.Zarn.Find(ZarnID);
            }
            zarn.Naziv = Naziv;
            zarn.Opis = Opis;

            db.SaveChanges();
            return Redirect("/Moderator/PrikazZarn");
        }
        public IActionResult Uredi(int ZarnID)
        {
            Zarn z = ZarnID == 0 ? new Zarn() : db.Zarn.Find(ZarnID);
            ViewData["zarn"] = z;
            return View("UrediZarn");
        }
        public IActionResult Obrisi(int ZarnID)
        {
            
            Zarn z = db.Zarn.Find(ZarnID);
            db.Remove(z);
            db.SaveChanges();
            return Redirect("/Moderator/PrikazZarn");
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
