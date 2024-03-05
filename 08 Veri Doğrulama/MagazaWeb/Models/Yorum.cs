using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagazaWeb.Models
{
    public class Yorum
    {
        [Display(Name="Yorum Konusu")]
        [Required(ErrorMessage = "{0} alanını doldur")]
       [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string? Konu { get; set; }  
        [Display(Name="Yorum Mesajı")]
        [Required(ErrorMessage = "{0} alanını doldur")]
        public string? Mesaj { get; set; }
        [Display(Name="Kullanıcı Puanı")]
        [Range(0, 100, ErrorMessage = "{0} {1}-{2} arası olmalı")]
        public int Puan { get; set; }
    }
}