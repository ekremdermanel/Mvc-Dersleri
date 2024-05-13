using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TelefonRehberi.Models
{
    public class Kisi
    {
        public int Id { get; set; }

        [Display(Name="İsim")]
        [Required(ErrorMessage = "{0} alanını doldur")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string Isim { get; set; }

        [Required(ErrorMessage="{0} giriniz")]
        public string Telefon { get; set; }

    }
}