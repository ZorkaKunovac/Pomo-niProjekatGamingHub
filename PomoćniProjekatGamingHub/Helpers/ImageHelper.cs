using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PomoćniProjekatGamingHub.Helpers
{
    public class ImageHelper
    {
        public static string GetImageBase64(byte[] slika)
        {
            return slika != null ? $"data:image/jpg;base64,{Convert.ToBase64String(slika)}" : null;
        }
        public static byte[] GetImageByteArray(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var fs = file.OpenReadStream())
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    return ms.ToArray();
                }
            }

            return null;
        }
    }
}
