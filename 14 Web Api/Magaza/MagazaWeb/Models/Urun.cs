using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MagazaWeb.Models
{
  public class Urun
  {
    public int Id { get; set; }

    [Display(Name = "Ürün Adı")]
    [Required(ErrorMessage = "{0} giriniz")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
    public string UrunAdi { get; set; }

    [Display(Name = "Ürün Fiyatı")]
    [Required(ErrorMessage = "{0} giriniz")]
    public decimal? Fiyat { get; set; }

    [Display(Name = "Stok Adedi")]
    [Required(ErrorMessage = "{0} giriniz")]
    [Range(0, 100, ErrorMessage = "{0} {1}-{2} arası olmalı")]
    public int? Stok { get; set; }

    [Display(Name = "Açıklama")]
    public string? Aciklama { get; set; }

    public DateTime EklenmeTarihi { get; set; }
  }
}