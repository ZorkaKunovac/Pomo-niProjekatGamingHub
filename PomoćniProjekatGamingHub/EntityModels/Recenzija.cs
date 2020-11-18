using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.EntityModels
{
    public class Recenzija
    {
        public int ID { get; set; }
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

        [MaxLength(250)]
        public string Naslov { get; set; }
        public DateTime? DatumKreiranja { get; set; }

        [MaxLength(2000)]
        public string Sadrzaj { get; set; }
        public virtual ICollection<RecenzijaZarn> RecenzijaZarn { get; set; }
    }
}
