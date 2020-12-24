using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.Models.IgraZarn
{
    public class IgraZarnPrikazVM
    {
        public class Rows
        {
            public int IgraZarnID { get; set; }
            public string Zarn { get; set; }
        }
        public int IgraID { get; set; }
        public List<Rows> rows { get; set; }
    }
}
