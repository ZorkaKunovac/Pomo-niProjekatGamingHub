using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PomoćniProjekatGamingHub.EF;
using PomoćniProjekatGamingHub.EntityModels;
using PomoćniProjekatGamingHub.Helpers;
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
                SlikaLink = ImageHelper.GetImageBase64(i.SlikaLink)
            }).ToList();
            return View(m);
        }

        [HttpGet]
        public IActionResult Dodaj()
        {
            List<CheckBoxHelper> listaKonzola = new List<CheckBoxHelper>();

            listaKonzola = db.Konzola.Select(a => new CheckBoxHelper
            {
                Id = a.Id,
                Text = a.Naziv,
                IsChecked = false,
                KonzolaId = a.Id
            }).ToList();

            IgraDodajVM model = new IgraDodajVM
            {
                CheckBox = listaKonzola
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Dodaj(IgraDodajVM igra, IFormFile file)
        {
            Igra novaIgra = new Igra
            {
                Naziv = igra.Naziv,
                Developer = igra.Developer,
                Izdavac = igra.Izdavac,
                DatumIzlaska = igra.DatumIzlaska,
                VideoLink = igra.VideoLink,
                SlikaLink = ImageHelper.GetImageByteArray(file),
            };
            db.Igra.Add(novaIgra);
            db.SaveChanges();

            foreach (var item in igra.CheckBox)
            {
                IgraKonzola k = new IgraKonzola
                {
                    IgraID = novaIgra.Id,
                    KonzolaID = item.KonzolaId,
                    IsChecked = item.IsChecked
                };
                db.IgraKonzola.Add(k);
            }
            db.SaveChanges();
            return Redirect("/Igra/Prikaz");
        }

        [HttpGet]

        public IActionResult Uredi(int IgraID)
        {
            var igraIzBaze = db.Igra.Find(IgraID);

            IgraUrediVM m = new IgraUrediVM
            {
                Id = IgraID,
                Naziv = igraIzBaze.Naziv,
                Developer = igraIzBaze.Developer,
                DatumIzlaska = igraIzBaze.DatumIzlaska,
                VideoLink = igraIzBaze.VideoLink,
                SlikaLink = ImageHelper.GetImageBase64(igraIzBaze.SlikaLink),

                Konzola = db.IgraKonzola
                .Where(ik => ik.IgraID == IgraID)
                .Select(ik => new CheckBoxHelper
                {
                    Id = ik.ID,
                    Text = ik.Konzola.Naziv,
                    IsChecked = ik.IsChecked,
                    KonzolaId = ik.KonzolaID
                }).ToList()
            };
            return View(m);
        }
        public IActionResult Snimi(IgraUrediVM i, IFormFile file)
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
            igra.VideoLink = i.VideoLink;

            var novaSlika = ImageHelper.GetImageByteArray(file);
            if (novaSlika != null)
            {
                igra.SlikaLink = novaSlika;
            }

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
                        VideoLink = i.VideoLink,
                        SlikaLink = ImageHelper.GetImageBase64(i.SlikaLink)
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
