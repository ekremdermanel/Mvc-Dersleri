using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrnekProje.Models
{
    public class Araba
    {
        public int Id { get; set; }

        [Display(Name = "Araba Markası")]
        [Required(ErrorMessage = "{0} giriniz")]
        public string Marka { get; set; } 
        
        [Required(ErrorMessage = "{0} giriniz")]
        public string Model { get; set; } 
        
        [Display(Name = "Model Yılı")]
        [Required(ErrorMessage = "{0} giriniz")]
        [Range(1900,2024,ErrorMessage = "{0} hatalı")]
        public int? Yil { get; set; }
    }
}