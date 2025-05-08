using Microsoft.AspNetCore.Mvc;
using SemWebApp.Models;
using SemWebApp.Services;

namespace SemWebApp.Controllers
{
    public class RandevuController : Controller
    {
        private readonly IRandevuService _randevuService;

        public RandevuController(IRandevuService randevuService)
        {
            _randevuService = randevuService;
        }

        // GET: Randevu
        public async Task<IActionResult> Index()
        {
            var randevular = await _randevuService.GetAllAsync();
            return View(randevular);
        }

        // GET: Randevu/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var randevu = await _randevuService.GetByIdAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            return View(randevu);
        }

        // GET: Randevu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Randevu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tarih,Saat,KullaniciId,DersId")] Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                await _randevuService.CreateAsync(randevu);
                return RedirectToAction(nameof(Index));
            }
            return View(randevu);
        }

        // GET: Randevu/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var randevu = await _randevuService.GetByIdAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            return View(randevu);
        }

        // POST: Randevu/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tarih,Saat,KullaniciId,DersId")] Randevu randevu)
        {
            if (id != randevu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _randevuService.UpdateAsync(id, randevu);
                return RedirectToAction(nameof(Index));
            }
            return View(randevu);
        }

        // GET: Randevu/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var randevu = await _randevuService.GetByIdAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            return View(randevu);
        }

        // POST: Randevu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _randevuService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}