using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.Models.IgraZarn
{
    public class IgraZarnDodajVM
    {
       // public int IgraZarnID { get; set; }
        public int IgraID { get; set; }
        public int ZarnID { get; set; }
        public List<SelectListItem> Zarnovi { get; set; }
    }
}
