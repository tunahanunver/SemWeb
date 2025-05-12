using Microsoft.AspNetCore.Mvc;
using SemWeb.Models;
using SemWebApi.Services.Interfaces;

namespace SemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdemeController : ControllerBase
    {
        private readonly IOdemeService _odemeService;

        public OdemeController(IOdemeService odemeService)
        {
            _odemeService = odemeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Odeme>>> GetOdemeler()
        {
            var odemeler = await _odemeService.GetAllAsync();
            return Ok(odemeler);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Odeme>> GetOdeme(int id)
        {
            var odeme = await _odemeService.GetByIdAsync(id);
            if (odeme == null)
                return NotFound();

            return Ok(odeme);
        }

        [HttpGet("kullanici/{kullaniciId}")]
        public async Task<ActionResult<IEnumerable<Odeme>>> GetOdemelerByKullanici(int kullaniciId)
        {
            var odemeler = await _odemeService.GetOdemeByKullaniciIdAsync(kullaniciId);
            return Ok(odemeler);
        }

        [HttpGet("abonelik/{abonelikId}")]
        public async Task<ActionResult<IEnumerable<Odeme>>> GetOdemelerByAbonelik(int abonelikId)
        {
            var odemeler = await _odemeService.GetOdemeByAbonelikIdAsync(abonelikId);
            return Ok(odemeler);
        }

        [HttpGet("tarih-arasi")]
        public async Task<ActionResult<IEnumerable<Odeme>>> GetOdemelerByTarihArasi(
            [FromQuery] DateTime baslangic,
            [FromQuery] DateTime bitis)
        {
            var odemeler = await _odemeService.GetOdemeByTarihArasiAsync(baslangic, bitis);
            return Ok(odemeler);
        }

        [HttpGet("durum/{durum}")]
        public async Task<ActionResult<IEnumerable<Odeme>>> GetOdemelerByDurum(string durum)
        {
            var odemeler = await _odemeService.GetOdemeByDurumAsync(durum);
            return Ok(odemeler);
        }

        [HttpGet("toplam")]
        public async Task<ActionResult<decimal>> GetTotalOdemeler(
            [FromQuery] DateTime baslangic,
            [FromQuery] DateTime bitis)
        {
            var total = await _odemeService.GetTotalOdemeByDateRangeAsync(baslangic, bitis);
            return Ok(total);
        }

        [HttpPost]
        public async Task<ActionResult<Odeme>> CreateOdeme(Odeme odeme)
        {
            var createdOdeme = await _odemeService.CreateAsync(odeme);
            return CreatedAtAction(nameof(GetOdeme), new { id = createdOdeme.Id }, createdOdeme);
        }

        [HttpPost("process")]
        public async Task<ActionResult<Odeme>> ProcessPayment(Odeme odeme)
        {
            var processedOdeme = await _odemeService.ProcessPaymentAsync(odeme);
            return CreatedAtAction(nameof(GetOdeme), new { id = processedOdeme.Id }, processedOdeme);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOdeme(int id, Odeme odeme)
        {
            var updatedOdeme = await _odemeService.UpdateAsync(id, odeme);
            if (updatedOdeme == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOdeme(int id)
        {
            await _odemeService.DeleteAsync(id);
            return NoContent();
        }
    }
}