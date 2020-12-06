using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.Models.Igra
{
    public class IgraDetaljiVM
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Developer { get; set; }
        public string Izdavac { get; set; }
        public DateTime? DatumIzlaska { get; set; }
        public List<SelectListItem> IgraZarn { get; set; }
        public List<SelectListItem> IgraKonzola { get; set; }
        public string VideoLink { get; set; }
        public string SlikaLink { get; set; }
        public string YouTubeId
        {
            get
            {
                string id = null;

                if (!string.IsNullOrEmpty(VideoLink) &&
                   (VideoLink.Contains("youtube.com") || VideoLink.Contains("youtu.be")))
                {
                    int lastIndexOf = VideoLink.LastIndexOf("v=");
                    if (lastIndexOf == 0)
                    {
                        lastIndexOf = VideoLink.LastIndexOf("/") + 1;
                    }
                    else
                    {
                        lastIndexOf += 2;
                    }
                    id = VideoLink.Substring(lastIndexOf);
                }
                return id;
            }
        }



    }
}
