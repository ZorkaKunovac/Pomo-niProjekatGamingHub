using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.EntityModels
{
    public class RecenzijaZarn
    {
        public int RecenzijaID { get; set; }
        public Recenzija Recenzija { get; set; }
        public int ZarnID { get; set; }
        public Zarn Zarn { get; set; }
    }
}
