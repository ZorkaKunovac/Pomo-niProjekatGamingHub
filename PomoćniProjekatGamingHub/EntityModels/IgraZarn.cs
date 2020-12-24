using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.EntityModels
{
    public class IgraZarn
    {
        public int ID { get; set; }
        public int IgraID { get; set; }
        public virtual Igra Igra { get; set; }
        public int ZarnID { get; set; }
        public virtual Zarn Zarn { get; set; }
    }
}
