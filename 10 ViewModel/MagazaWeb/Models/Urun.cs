using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public decimal? Fiyat { get; set; }
        public int? Stok { get; set; }
        public string? Aciklama { get; set; }
        public DateTime EklenmeTarihi { get; set; }
    }
}