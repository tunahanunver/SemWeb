using Microsoft.AspNetCore.Mvc;
using SemWebApp.Models;
using SemWebApp.Services;

namespace SemWebApp.Controllers
{
    public class OdemeController : Controller
    {
        private readonly IOdemeService _odemeService;

        public OdemeController(IOdemeService odemeService)
        {
            _odemeService = odemeService;
        }

        // GET: Odeme
        public async Task<IActionResult> Index()
        {
            var odemeler = await _odemeService.GetAllAsync();
            return View(odemeler);
        }

        // GET: Odeme/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var odeme = await _odemeService.GetByIdAsync(id);
            if (odeme == null)
            {
                return NotFound();
            }
            return View(odeme);
        }

        // GET: Odeme/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Odeme/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tutar,OdemeTarihi,KullaniciId")] Odeme odeme)
        {
            if (ModelState.IsValid)
            {
                await _odemeService.CreateAsync(odeme);
                return RedirectToAction(nameof(Index));
            }
            return View(odeme);
        }

        // GET: Odeme/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var odeme = await _odemeService.GetByIdAsync(id);
            if (odeme == null)
            {
                return NotFound();
            }
            return View(odeme);
        }

        // POST: Odeme/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tutar,OdemeTarihi,KullaniciId")] Odeme odeme)
        {
            if (id != odeme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _odemeService.UpdateAsync(id, odeme);
                return RedirectToAction(nameof(Index));
            }
            return View(odeme);
        }

        // GET: Odeme/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var odeme = await _odemeService.GetByIdAsync(id);
            if (odeme == null)
            {
                return NotFound();
            }
            return View(odeme);
        }

        // POST: Odeme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _odemeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}