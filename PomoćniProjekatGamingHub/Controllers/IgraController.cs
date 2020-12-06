using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PomoćniProjekatGamingHub.EF;
using PomoćniProjekatGamingHub.EntityModels;
using PomoćniProjekatGamingHub.Models;
using PomoćniProjekatGamingHub.Models.Igra;

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

        //NIJE RIJESENA KONEKCIJA SA ZARNOM I KONZOLAMA
        //NIJE RIJESENA KONEKCIJA SA ZARNOM I KONZOLAMA
        public IActionResult Uredi(int IgraID)
        {
            IgraUrediVM m;
            if (IgraID == 0)
            {
                m = new IgraUrediVM() { };
            }
            else
            {
                m = db.Igra.Where(i => i.Id == IgraID)
                    .Select(i => new IgraUrediVM
                    {
                        Id = i.Id,
                        Naziv = i.Naziv,
                        DatumIzlaska = i.DatumIzlaska,
                        Developer = i.Developer,
                        Izdavac = i.Izdavac,
                        SlikaLink = i.SlikaLink,
                        VideoLink = i.VideoLink
                    }).Single();
            }
            return View(m);
        }
        public IActionResult Snimi(IgraUrediVM i)
        {
            Igra igra;
            if (i.Id == 0)
            {
                igra = new Igra();
                db.Add(igra);
            }
            else
            {
                igra = db.Igra.Find(i.Id);
            }
            igra.Id = i.Id;
            igra.Naziv = i.Naziv;
            igra.DatumIzlaska = i.DatumIzlaska;
            igra.Developer = i.Developer;
            igra.Izdavac = i.Izdavac;
            igra.SlikaLink = i.SlikaLink;
            igra.VideoLink = i.VideoLink;

            db.SaveChanges();
            return Redirect("/Igra/Prikaz");
        }
        public IActionResult Detalji(int IgraID)
        {
           var m = db.Igra.Where(i => i.Id == IgraID)
                    .Select(i => new IgraDetaljiVM
                    {
                        Id = i.Id,
                        Naziv = i.Naziv,
                        DatumIzlaska = i.DatumIzlaska,
                        Developer = i.Developer,
                        Izdavac = i.Izdavac,
                        SlikaLink = i.SlikaLink,
                        VideoLink = i.VideoLink
                    }).FirstOrDefault();

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
