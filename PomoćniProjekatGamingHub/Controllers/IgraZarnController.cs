using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PomoćniProjekatGamingHub.EF;
using PomoćniProjekatGamingHub.EntityModels;
using PomoćniProjekatGamingHub.Models.IgraZarn;

namespace PomoćniProjekatGamingHub.Controllers
{
    public class IgraZarnController : Controller
    {
        MojDbContext db = new MojDbContext();
        public IActionResult Index(int IgraID)
        {
            IgraZarnPrikazVM m = new IgraZarnPrikazVM();
            m.rows = db.IgraZarn.Where(iz => iz.IgraID == IgraID)
             .Select(iz => new IgraZarnPrikazVM.Rows
             {
                 IgraZarnID = iz.ID,
                 Zarn = iz.Zarn.Naziv
             }).ToList();
            m.IgraID = IgraID;
            return View(m);
        }
        public IActionResult Dodaj(int IgraID)
        {
            IgraZarnDodajVM m = new IgraZarnDodajVM();
            m.IgraID = IgraID;
            //List<IgraZarn> igraZarnovi = db.IgraZarn.Where(iz => iz.IgraID == IgraID).ToList();
            //igraZarnovi.ForEach(iz =>
            //{
            //    //var KolekcijaZarnova = db.Zarn.Where(z => z.Id != iz.ZarnID).ToList();
            //    m.Zarnovi = db.Zarn.Where(z => z.Id != iz.ZarnID)
            //    .Select(z => new SelectListItem
            //    {
            //        Value = z.Id.ToString(),
            //        Text = z.Naziv
            //    }).ToList();
            //});
            m.Zarnovi = db.Zarn.Select(z => new SelectListItem
            {
                Value = z.Id.ToString(),
                Text = z.Naziv
            }).ToList();

            return View(m);
        }
        public IActionResult Snimi(IgraZarnDodajVM i)
        {
            IgraZarn igraZarn = new IgraZarn
            {
                IgraID = i.IgraID,
                ZarnID = i.ZarnID
            };
            db.Add(igraZarn);

            db.SaveChanges();
            return Redirect("/Igra/Detalji?IgraID=" + igraZarn.IgraID);
        }

        public IActionResult Obrisi(int IgraZarnID)
        {
            IgraZarn igraZarn = db.IgraZarn.Find(IgraZarnID);
            db.Remove(igraZarn);
            db.SaveChanges();

            return Redirect("/Igra/Detalji?IgraID=" + igraZarn.IgraID);
        }
    }
}
