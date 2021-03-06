﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.EntityModels
{
    public class Igra
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Developer { get; set; }
        public string Izdavac { get; set; }
        public DateTime? DatumIzlaska { get; set; }

        [MaxLength(100)]
        public string VideoLink { get; set; }
        public byte[] SlikaLink { get; set; }
        public Proizvod Proizvod { get; set; }
        //public virtual ICollection<IgraZarn> IgraZarn { get; set; }
        //public virtual ICollection<IgraKonzola> IgraKonzola { get; set; }
        public virtual ICollection<IgraTag> IgraTag { get; set; }
    }
}
