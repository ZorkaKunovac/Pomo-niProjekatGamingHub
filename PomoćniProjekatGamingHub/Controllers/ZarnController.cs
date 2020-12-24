using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PomoćniProjekatGamingHub.EF;
using PomoćniProjekatGamingHub.EntityModels;
using PomoćniProjekatGamingHub.Models.Zarn;

namespace PomoćniProjekatGamingHub.Controllers
{
    public class ZarnController : Controller
    {
        MojDbContext db = new MojDbContext();
        public IActionResult Prikaz()
        {
            var zarnovi = db.Zarn
                .Select(z => new ZarnPrikazVM
                {
                    Id = z.Id,
                    Naziv = z.Naziv,
                    Opis = z.Opis
                }).ToList();

            return View(zarnovi);
        }
        public IActionResult Uredi(int ZarnID)
        {
            ZarnUrediVM zarn;
            if (ZarnID == 0)
            {
                zarn = new ZarnUrediVM() { };
            }
            else
            {
                zarn = db.Zarn.Where(z => z.Id == ZarnID)
                .Select(z => new ZarnUrediVM
                {
                    Id = z.Id,
                    Naziv = z.Naziv,
                    Opis = z.Opis
                }).Single();
            }

            return View(zarn);
        }
        public IActionResult Snimi(ZarnUrediVM z)
        {
            Zarn zarn;
            if (z.Id == 0)
            {
                zarn = new Zarn();
                db.Add(zarn);
            }
            else
            {
                zarn = db.Zarn.Find(z.Id);
            }
            zarn.Naziv = z.Naziv;
            zarn.Opis = z.Opis;

            db.SaveChanges();
            return Redirect("/Zarn/Prikaz");
        }
        public IActionResult Obrisi(int ZarnID)
        {
            Zarn z = db.Zarn.Find(ZarnID);
            db.Remove(z);
            db.SaveChanges();
            return Redirect("/Zarn/Prikaz");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
