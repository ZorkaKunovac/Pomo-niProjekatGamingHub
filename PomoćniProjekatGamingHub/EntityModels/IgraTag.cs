using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.EntityModels
{
    public class IgraTag
    {
        public int IgraID { get; set; }
        public Igra Igra { get; set; }
        public int TagID { get; set; }
        public Tag Tag { get; set; }
    }
}
