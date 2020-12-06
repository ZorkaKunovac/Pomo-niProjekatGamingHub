using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.Models
{
    public class IgraDodajVM
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Developer { get; set; }
        public string Izdavac { get; set; }
        public DateTime? DatumIzlaska { get; set; }
        public List<SelectListGroup> IgraZarn { get; set; }
        public List<SelectListGroup> IgraKonzola { get; set; }
        public string VideoLink { get; set; }
        public string SlikaLink { get; set; }
        
    }
}
