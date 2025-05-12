using Microsoft.AspNetCore.Mvc;
using SemWeb.Models;
using SemWebApi.Services.Interfaces;

namespace SemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandevuController : ControllerBase
    {
        private readonly IRandevuService _randevuService;

        public RandevuController(IRandevuService randevuService)
        {
            _randevuService = randevuService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Randevu>>> GetRandevular()
        {
            var randevular = await _randevuService.GetAllAsync();
            return Ok(randevular);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Randevu>> GetRandevu(int id)
        {
            var randevu = await _randevuService.GetByIdAsync(id);
            if (randevu == null)
                return NotFound();

            return Ok(randevu);
        }

        [HttpGet("kullanici/{kullaniciId}")]
        public async Task<ActionResult<IEnumerable<Randevu>>> GetRandevularByKullanici(int kullaniciId)
        {
            var randevular = await _randevuService.GetRandevuByKullaniciIdAsync(kullaniciId);
            return Ok(randevular);
        }

        [HttpGet("ders/{dersId}")]
        public async Task<ActionResult<IEnumerable<Randevu>>> GetRandevularByDers(int dersId)
        {
            var randevular = await _randevuService.GetRandevuByDersIdAsync(dersId);
            return Ok(randevular);
        }

        [HttpGet("tarih")]
        public async Task<ActionResult<IEnumerable<Randevu>>> GetRandevularByTarih([FromQuery] DateTime tarih)
        {
            var randevular = await _randevuService.GetRandevuByTarihAsync(tarih);
            return Ok(randevular);
        }

        [HttpGet("gelecek")]
        public async Task<ActionResult<IEnumerable<Randevu>>> GetFutureRandevular()
        {
            var randevular = await _randevuService.GetFutureRandevuAsync();
            return Ok(randevular);
        }

        [HttpGet("kontrol-zaman")]
        public async Task<ActionResult<bool>> CheckTimeSlotAvailability(
            [FromQuery] int dersId,
            [FromQuery] DateTime baslangicZamani,
            [FromQuery] DateTime bitisZamani)
        {
            var isAvailable = await _randevuService.IsTimeSlotAvailableAsync(dersId, baslangicZamani, bitisZamani);
            return Ok(isAvailable);
        }

        [HttpPost]
        public async Task<ActionResult<Randevu>> CreateRandevu(Randevu randevu)
        {
            try
            {
                var createdRandevu = await _randevuService.CreateAsync(randevu);
                return CreatedAtAction(nameof(GetRandevu), new { id = createdRandevu.Id }, createdRandevu);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRandevu(int id, Randevu randevu)
        {
            try
            {
                var updatedRandevu = await _randevuService.UpdateAsync(id, randevu);
                if (updatedRandevu == null)
                    return NotFound();

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRandevu(int id)
        {
            await _randevuService.DeleteAsync(id);
            return NoContent();
        }
    }
}