using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.Models.Konzola
{
    public class KonzolaUrediVM
    {
        public int KonzolaID { get; set; }
        public string Naziv { get; set; }
        public string Proizvodjac { get; set; }
        public int Kapacitet { get; set; }
        public string Detalji { get; set; }
    }
}
