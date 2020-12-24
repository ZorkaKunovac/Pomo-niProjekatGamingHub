using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Obrisi(int IgraZarnID)
        {
            IgraZarn igraZarn = db.IgraZarn.Find(IgraZarnID);
            db.Remove(igraZarn);
            db.SaveChanges();

            return Redirect("/Igra/Detalji?IgraID=" + igraZarn.IgraID);
        }
    }
}
