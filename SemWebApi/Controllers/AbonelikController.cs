using Microsoft.AspNetCore.Mvc;
using SemWeb.Models;
using SemWebApi.Services.Interfaces;

namespace SemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonelikController : ControllerBase
    {
        private readonly IAbonelikService _abonelikService;

        public AbonelikController(IAbonelikService abonelikService)
        {
            _abonelikService = abonelikService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Abonelik>>> GetAbonelikler()
        {
            var abonelikler = await _abonelikService.GetAllAsync();
            return Ok(abonelikler);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Abonelik>> GetAbonelik(int id)
        {
            var abonelik = await _abonelikService.GetByIdAsync(id);
            if (abonelik == null)
                return NotFound();

            return Ok(abonelik);
        }

        [HttpGet("kullanici/{kullaniciId}")]
        public async Task<ActionResult<IEnumerable<Abonelik>>> GetAboneliklerByKullanici(int kullaniciId)
        {
            var abonelikler = await _abonelikService.GetAbonelikByKullaniciIdAsync(kullaniciId);
            return Ok(abonelikler);
        }

        [HttpGet("aktif")]
        public async Task<ActionResult<IEnumerable<Abonelik>>> GetActiveAbonelikler()
        {
            var abonelikler = await _abonelikService.GetActiveAbonelikAsync();
            return Ok(abonelikler);
        }

        [HttpGet("sonlanmis")]
        public async Task<ActionResult<IEnumerable<Abonelik>>> GetExpiredAbonelikler()
        {
            var abonelikler = await _abonelikService.GetExpiredAbonelikAsync();
            return Ok(abonelikler);
        }

        [HttpGet("tur/{tur}")]
        public async Task<ActionResult<IEnumerable<Abonelik>>> GetAboneliklerByTur(string tur)
        {
            var abonelikler = await _abonelikService.GetAbonelikByTurAsync(tur);
            return Ok(abonelikler);
        }

        [HttpGet("aktif-kullanici/{kullaniciId}")]
        public async Task<ActionResult<Abonelik>> GetActiveAbonelikByKullanici(int kullaniciId)
        {
            var abonelik = await _abonelikService.GetActiveAbonelikByKullaniciIdAsync(kullaniciId);
            if (abonelik == null)
                return NotFound();

            return Ok(abonelik);
        }

        [HttpPost]
        public async Task<ActionResult<Abonelik>> CreateAbonelik(Abonelik abonelik)
        {
            try
            {
                var createdAbonelik = await _abonelikService.CreateAsync(abonelik);
                return CreatedAtAction(nameof(GetAbonelik), new { id = createdAbonelik.Id }, createdAbonelik);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAbonelik(int id, Abonelik abonelik)
        {
            var updatedAbonelik = await _abonelikService.UpdateAsync(id, abonelik);
            if (updatedAbonelik == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbonelik(int id)
        {
            await _abonelikService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("yenile/{id}")]
        public async Task<ActionResult<Abonelik>> YenileAbonelik(int id, [FromQuery] int ayEkle = 1)
        {
            var yenilenenAbonelik = await _abonelikService.YenileAbonelikAsync(id, ayEkle);
            if (yenilenenAbonelik == null)
                return NotFound();

            return Ok(yenilenenAbonelik);
        }
    }
}