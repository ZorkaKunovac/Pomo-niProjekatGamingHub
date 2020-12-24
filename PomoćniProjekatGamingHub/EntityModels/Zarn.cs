using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.EntityModels
{
    public class Zarn
    {
        
        public int Id { get; set; }

        [MaxLength(100)]
        public string Naziv { get; set; }

        [MaxLength(2000)]
        public string Opis { get; set; }
        //public virtual ICollection<IgraZarn> IgraZarn { get; set; }

    }
}
