using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.EntityModels
{
    public class IgraZarn
    {
        public int IgraID { get; set; }
        public Igra Igra { get; set; }
        public int ZarnID { get; set; }
        public Zarn Zarn { get; set; }
    }
}