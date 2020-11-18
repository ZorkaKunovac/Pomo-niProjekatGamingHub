using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PomoćniProjekatGamingHub.Controllers
{
    public class KorisnikController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
