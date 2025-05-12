using Microsoft.AspNetCore.Mvc;
using SemWeb.Models;
using SemWebApi.Services.Interfaces;

namespace SemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly IKullaniciService _kullaniciService;

        public KullaniciController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kullanici>>> GetKullanicilar()
        {
            var kullanicilar = await _kullaniciService.GetAllAsync();
            return Ok(kullanicilar);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kullanici>> GetKullanici(int id)
        {
            var kullanici = await _kullaniciService.GetByIdAsync(id);
            if (kullanici == null)
                return NotFound();

            return Ok(kullanici);
        }

        [HttpPost]
        public async Task<ActionResult<Kullanici>> CreateKullanici(Kullanici kullanici)
        {
            var createdKullanici = await _kullaniciService.CreateAsync(kullanici);
            return CreatedAtAction(nameof(GetKullanici), new { id = createdKullanici.Id }, createdKullanici);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKullanici(int id, Kullanici kullanici)
        {
            var updatedKullanici = await _kullaniciService.UpdateAsync(id, kullanici);
            if (updatedKullanici == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKullanici(int id)
        {
            await _kullaniciService.DeleteAsync(id);
            return NoContent();
        }
    }
}