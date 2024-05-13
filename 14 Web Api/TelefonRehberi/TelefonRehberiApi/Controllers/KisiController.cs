using Microsoft.AspNetCore.Mvc;
using TelefonRehberiApi.Models;

namespace TelefonRehberiApi.Controllers;

[ApiController]
[Route("[controller]")]
public class KisiController : ControllerBase
{
    private readonly Context context;

    public KisiController(Context context)
    {
        this.context = context;
    }

    [HttpGet("Liste")]
    public IActionResult Liste()
    {
        return Ok(context.Kisiler.ToList());
    }

    [HttpGet("Detay/{id:int}")]
    public IActionResult Detay([FromRoute] int id)
    {
        Kisi kayit = context.Kisiler.FirstOrDefault(x => x.Id == id);
        return Ok(kayit);
    }

    [HttpPost("Ekle")]
    public IActionResult Ekle([FromBody] Kisi model)
    {
        context.Kisiler.Add(model);
        context.SaveChanges();
        return Ok(model);
    }

    [HttpDelete("Sil/{id:int}")]
    public IActionResult Sil([FromRoute] int id)
    {
        Kisi kayit = context.Kisiler.FirstOrDefault(x => x.Id == id);
        context.Kisiler.Remove(kayit);
        context.SaveChanges();
        return NoContent();
    }

    [HttpPut("Guncelle")]
    public IActionResult Guncelle([FromBody] Kisi model)
    {
        context.Kisiler.Update(model);
        context.SaveChanges();
        return Ok(model);
    }

    /*
    [HttpGet("Liste")]
    public IActionResult Liste()
    {
        return Ok(context.Kisiler.ToList());
    }

    [HttpGet("Detay/{id:int}")]
    public IActionResult Detay([FromRoute] int id)
    {
        Kisi kayit = context.Kisiler.FirstOrDefault(x => x.Id == id);
        if (kayit == null)
        {
            return NotFound();
        }
        return Ok(kayit);
    }

    [HttpPost("Ekle")]
    public IActionResult Ekle([FromBody] Kisi model)
    {
        try
        {
            if (model is null)
                return BadRequest();

            context.Kisiler.Add(model);
            context.SaveChanges();
            return StatusCode(201, model);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("Sil/{id:int}")]
    public IActionResult Sil([FromRoute] int id)
    {
        Kisi kayit = context.Kisiler.FirstOrDefault(x => x.Id == id);

        if (kayit is null)
            return NotFound(new
            {
                statusCode = 404,
                message = $"{id} id numaralı kayıt bulunamadı."
            });

        context.Kisiler.Remove(kayit);
        context.SaveChanges();
        return NoContent();
    }

    [HttpPut("Guncelle/{id:int}")]
    public IActionResult Guncelle([FromRoute] int id, [FromBody] Kisi model)
    {
        Kisi kayit = context.Kisiler.FirstOrDefault(x => x.Id == id);

        if (kayit is null)
            return NotFound(); //404

        if (id != kayit.Id)
            return BadRequest();//400


        kayit.AdSoyad = model.AdSoyad;
        kayit.Telefon = model.Telefon;
        context.SaveChanges();
        model.Id = kayit.Id;
        return Ok(model);
    }
    */
}
