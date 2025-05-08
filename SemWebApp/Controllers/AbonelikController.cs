using Microsoft.AspNetCore.Mvc;
using SemWebApp.Models;
using SemWebApp.Services;

namespace SemWebApp.Controllers
{
    public class AbonelikController : Controller
    {
        private readonly IAbonelikService _abonelikService;

        public AbonelikController(IAbonelikService abonelikService)
        {
            _abonelikService = abonelikService;
        }

        // GET: Abonelik
        public async Task<IActionResult> Index()
        {
            var abonelikler = await _abonelikService.GetAllAsync();
            return View(abonelikler);
        }

        // GET: Abonelik/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var abonelik = await _abonelikService.GetByIdAsync(id);
            if (abonelik == null)
            {
                return NotFound();
            }
            return View(abonelik);
        }

        // GET: Abonelik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Abonelik/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BaslangicTarihi,BitisTarihi,KullaniciId")] Abonelik abonelik)
        {
            if (ModelState.IsValid)
            {
                await _abonelikService.CreateAsync(abonelik);
                return RedirectToAction(nameof(Index));
            }
            return View(abonelik);
        }

        // GET: Abonelik/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var abonelik = await _abonelikService.GetByIdAsync(id);
            if (abonelik == null)
            {
                return NotFound();
            }
            return View(abonelik);
        }

        // POST: Abonelik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BaslangicTarihi,BitisTarihi,KullaniciId")] Abonelik abonelik)
        {
            if (id != abonelik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _abonelikService.UpdateAsync(id, abonelik);
                return RedirectToAction(nameof(Index));
            }
            return View(abonelik);
        }

        // GET: Abonelik/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var abonelik = await _abonelikService.GetByIdAsync(id);
            if (abonelik == null)
            {
                return NotFound();
            }
            return View(abonelik);
        }

        // POST: Abonelik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _abonelikService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}