using Microsoft.AspNetCore.Mvc;
using SemWeb.Models;
using SemWebApi.Services.Interfaces;

namespace SemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DersController : ControllerBase
    {
        private readonly IDersService _dersService;

        public DersController(IDersService dersService)
        {
            _dersService = dersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ders>>> GetDersler()
        {
            var dersler = await _dersService.GetAllAsync();
            return Ok(dersler);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ders>> GetDers(int id)
        {
            var ders = await _dersService.GetByIdAsync(id);
            if (ders == null)
                return NotFound();

            return Ok(ders);
        }

        [HttpGet("aktif")]
        public async Task<ActionResult<IEnumerable<Ders>>> GetActiveDersler()
        {
            var dersler = await _dersService.GetActiveCoursesAsync();
            return Ok(dersler);
        }

        [HttpGet("egitmen/{egitmenId}")]
        public async Task<ActionResult<IEnumerable<Ders>>> GetDerslerByEgitmen(int egitmenId)
        {
            var dersler = await _dersService.GetDersByEgitmenIdAsync(egitmenId);
            return Ok(dersler);
        }

        [HttpGet("tip/{dersTipi}")]
        public async Task<ActionResult<IEnumerable<Ders>>> GetDerslerByTip(string dersTipi)
        {
            var dersler = await _dersService.GetDersByTypeAsync(dersTipi);
            return Ok(dersler);
        }

        [HttpPost]
        public async Task<ActionResult<Ders>> CreateDers(Ders ders)
        {
            var createdDers = await _dersService.CreateAsync(ders);
            return CreatedAtAction(nameof(GetDers), new { id = createdDers.Id }, createdDers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDers(int id, Ders ders)
        {
            var updatedDers = await _dersService.UpdateAsync(id, ders);
            if (updatedDers == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDers(int id)
        {
            await _dersService.DeleteAsync(id);
            return NoContent();
        }
    }
}