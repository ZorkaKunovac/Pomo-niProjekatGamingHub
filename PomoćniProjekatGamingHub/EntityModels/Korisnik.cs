using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.EntityModels
{
    public class Korisnik
    {
        public int Id { get; set; }
        public int TipKorisnikaId { get; set; }
        public TipKorisnika TipKorisnika { get; set; }

        [MaxLength(50)]
        public string KorisnickoIme { get; set; }

        [MaxLength(100)]
        public string Lozinka { get; set; }

        [MaxLength(50)]
        public string Ime { get; set; }

        [MaxLength(50)]
        public string Prezime { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(10)]
        public string Spol { get; set; }

        public DateTime? DatumRodjenja { get; set; }

        [DefaultValue(false)]
        public bool Verifikovan { get; set; }
    }
}
