using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.EntityModels
{
    public class Proizvod
    {
        public int Id { get; set; }
        public string ImeProizvoda { get; set; }
        public string Opis { get; set; }
        public int NabavnaCijena { get; set; }
        public int ProdajnaCijena { get; set; }
        public float Popust { get; set; }
        public int IgraID { get; set; }
        public Igra Igra { get; set; }
    }
}
