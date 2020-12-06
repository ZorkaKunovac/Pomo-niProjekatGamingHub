using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.Models
{
    public class IgraPrikazVM
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Developer { get; set; }
        public string Izdavac { get; set; }
        public DateTime? DatumIzlaska { get; set; }
        public string SlikaLink { get; set; }
    }
}
