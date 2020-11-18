using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.EntityModels
{
    public class Konzola
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Proizvodjac { get; set; }
        public int Kapacitet { get; set; }
        public string Detalji { get; set; }
        public virtual ICollection<IgraKonzola> IgraKonzola { get; set; }
    }
}
