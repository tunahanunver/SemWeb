using Microsoft.AspNetCore.Mvc;
using SemWebApp.Models;
using SemWebApp.Services;

namespace SemWebApp.Controllers
{
    public class DersController : Controller
    {
        private readonly IDersService _dersService;

        public DersController(IDersService dersService)
        {
            _dersService = dersService;
        }

        // GET: Ders
        public async Task<IActionResult> Index()
        {
            var dersler = await _dersService.GetAllAsync();
            return View(dersler);
        }

        // GET: Ders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var ders = await _dersService.GetByIdAsync(id);
            if (ders == null)
            {
                return NotFound();
            }
            return View(ders);
        }

        // GET: Ders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DersAdi,Aciklama")] Ders ders)
        {
            if (ModelState.IsValid)
            {
                await _dersService.CreateAsync(ders);
                return RedirectToAction(nameof(Index));
            }
            return View(ders);
        }

        // GET: Ders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var ders = await _dersService.GetByIdAsync(id);
            if (ders == null)
            {
                return NotFound();
            }
            return View(ders);
        }

        // POST: Ders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DersAdi,Aciklama")] Ders ders)
        {
            if (id != ders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _dersService.UpdateAsync(id, ders);
                return RedirectToAction(nameof(Index));
            }
            return View(ders);
        }

        // GET: Ders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var ders = await _dersService.GetByIdAsync(id);
            if (ders == null)
            {
                return NotFound();
            }
            return View(ders);
        }

        // POST: Ders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _dersService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}