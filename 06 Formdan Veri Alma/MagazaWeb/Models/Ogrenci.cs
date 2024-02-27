using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Models
{
    public class Ogrenci
    {
        public string AdSoyad { get; set; }
        public int Sinav1 { get; set; }
        public int Sinav2 { get; set; }
        public IFormFile Resim { get; set; }
    }
}