using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Models
{
    public class Kategori
    {
        public int Id { get; set; }

        [Display(Name = "Kategori Adı")]
        [Required(ErrorMessage = "{0} giriniz")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string KategoriAdi { get; set; }

        [Display(Name = "Kategori Sloganı")]
        public string? Slogan { get; set; }

        public List<Urun>? Urunler { get; set; }
    }
}