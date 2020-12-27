using PomoćniProjekatGamingHub.EntityModels;
using PomoćniProjekatGamingHub.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.Models.Igra
{
    public class IgraDodajVM
    {
        public string Naziv { get; set; }
        public string Developer { get; set; }
        public string Izdavac { get; set; }
        public DateTime? DatumIzlaska { get; set; }
        public string VideoLink { get; set; }
        public string SlikaLink { get; set; }
        public int KonzolaId { get; set; }
        public List<IgraKonzola> Konzola { get; set; }
        public List<CheckBoxHelper> CheckBox { get; set; }
    }
}
