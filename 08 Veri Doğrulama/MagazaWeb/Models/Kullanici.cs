using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Models
{
    public class Kullanici
    {
        [Display(Name="Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} giriniz")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Harf ve rakamlardan oluşmalı")]
        public string KullaniciAdi { get; set; }

        [Display(Name="Şifre")]
        [Required(ErrorMessage = "{0} giriniz")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        [Display(Name="Şifre (Tekrar)")]
        [Required(ErrorMessage = "{0} giriniz")]
        [Compare("Sifre",ErrorMessage="Şifreler aynı olmalı")]
        [DataType(DataType.Password)]
        public string SifreTekrar { get; set; }

        [Display(Name="E-posta Adresi")]
        [EmailAddress]
        public string? Eposta { get; set; }
        
        [Display(Name="Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? DogumTarihi { get; set; }
    }
}