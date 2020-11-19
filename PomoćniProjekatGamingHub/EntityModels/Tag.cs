using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.EntityModels
{
    public class Tag
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public virtual ICollection<IgraTag> IgraTag { get; set; }
    }
}
