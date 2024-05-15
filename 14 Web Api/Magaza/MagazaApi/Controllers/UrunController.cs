using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagazaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagazaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrunController : ControllerBase
    {
        private readonly MagazaContext context;
        public UrunController(MagazaContext context)
        {
            this.context = context;
        }

        [HttpGet("Liste")]
        public IActionResult Liste()
        {
            return Ok(context.Urunler.ToArray());
        }

        [HttpGet("Detay/{id}")]
        public IActionResult Detay(int id)
        {
            Urun kayit = context.Urunler.FirstOrDefault(x => x.Id == id);
            return Ok(kayit);
        }

        [HttpPost("Ekle")]
        public IActionResult Ekle(Urun model)
        {
            model.EklenmeTarihi = DateTime.Now;
            context.Urunler.Add(model);
            context.SaveChanges();
            return Ok(true);
        }

        [HttpDelete("Sil/{id}")]
        public IActionResult Sil(int id)
        {
            Urun kayit = context.Urunler.FirstOrDefault(x => x.Id == id);
            context.Urunler.Remove(kayit);
            context.SaveChanges();
            return Ok(true);
        }

        [HttpPut("Guncelle")]
        public IActionResult Guncelle(Urun model)
        {
            context.Urunler.Update(model);
            context.SaveChanges();
            return Ok(true);
        }
    }
}