using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PomoćniProjekatGamingHub.EF;
using PomoćniProjekatGamingHub.EntityModels;

namespace PomoćniProjekatGamingHub.Controllers
{
    public class ModeratorController : Controller
    {
        public IActionResult KonzolaPrikaz()
        {
            MojDbContext db = new MojDbContext();
            List<Konzola> konzole = db.Konzola.ToList();
            ViewData["konzole"] = konzole;
            return View("KonzolaPrikaz");
        }
        public IActionResult ListaIgara()
        {
            MojDbContext db = new MojDbContext();
            List<Igra> igre = db.Igra.ToList();
            ViewData["igre"] = igre;
            return View("ListaIgara");
        }
        public IActionResult ListaRecenzija()
        {
            MojDbContext db = new MojDbContext();
            List<Recenzija> recenzije = db.Recenzija.ToList();
            ViewData["recenzije"] = recenzije;
            return View("ListaRecenzija");
        }
        public IActionResult SnimiKonzolu(int KonzolaID, string Naziv, string Proizvodjac, int Kapacitet, string Detalji)
        {
            MojDbContext db = new MojDbContext();
            Konzola konzola;
            if (KonzolaID == 0)
            {
                konzola = new Konzola();
                db.Add(konzola);
            }
            else
            {
                konzola = db.Konzola.Find(KonzolaID);
            }
            konzola.Naziv = Naziv;
            konzola.Proizvodjac = Proizvodjac;
            konzola.Kapacitet = Kapacitet;
            konzola.Detalji = Detalji;

            db.SaveChanges();
            return Redirect("/Moderator/KonzolaPrikaz");
        }

        public IActionResult UrediKonzolu(int KonzolaID)
        {
            MojDbContext db = new MojDbContext();

            Konzola k = KonzolaID == 0 ? new Konzola() : db.Konzola.Find(KonzolaID);
            ViewData["konzola"] = k;
            return View("UrediKonzolu");
        }
        public IActionResult ObrisiKonzolu(int KonzolaID)
        {
            MojDbContext db = new MojDbContext();
            Konzola k = db.Konzola.Find(KonzolaID);
            db.Remove(k);
            db.SaveChanges();
            return Redirect("/Moderator/KonzolaPrikaz");
        }

        public IActionResult PrikazZarn()
        {
            MojDbContext db = new MojDbContext();
            List<Zarn> zarnovi = db.Zarn.ToList();

            ViewData["zarnovi"] = zarnovi;
            return View("PrikazZarn");
        }
        public IActionResult SnimiZarn(int ZarnID, string Naziv, string Opis)
        {
            MojDbContext db = new MojDbContext();
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
            MojDbContext db = new MojDbContext();

            Zarn z = ZarnID == 0 ? new Zarn() : db.Zarn.Find(ZarnID);
            ViewData["zarn"] = z;
            return View("UrediZarn");
        }
        public IActionResult Obrisi(int ZarnID)
        {
            MojDbContext db = new MojDbContext();
            Zarn z = db.Zarn.Find(ZarnID);
            db.Remove(z);
            db.SaveChanges();
            return Redirect("/Moderator/PrikazZarn");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
