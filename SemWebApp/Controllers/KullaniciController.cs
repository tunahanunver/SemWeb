using Microsoft.AspNetCore.Mvc;
using SemWebApp.Models;
using SemWebApp.Services;

namespace SemWebApp.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IKullaniciService _kullaniciService;

        public KullaniciController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        // GET: Kullanici
        public async Task<IActionResult> Index()
        {
            var kullanicilar = await _kullaniciService.GetAllAsync();
            return View(kullanicilar);
        }

        // GET: Kullanici/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var kullanici = await _kullaniciService.GetByIdAsync(id);
            if (kullanici == null)
            {
                return NotFound();
            }
            return View(kullanici);
        }

        // GET: Kullanici/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kullanici/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ad,Soyad,Email,Telefon")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                await _kullaniciService.CreateAsync(kullanici);
                return RedirectToAction(nameof(Index));
            }
            return View(kullanici);
        }

        // GET: Kullanici/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var kullanici = await _kullaniciService.GetByIdAsync(id);
            if (kullanici == null)
            {
                return NotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanici/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Soyad,Email,Telefon")] Kullanici kullanici)
        {
            if (id != kullanici.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _kullaniciService.UpdateAsync(id, kullanici);
                return RedirectToAction(nameof(Index));
            }
            return View(kullanici);
        }

        // GET: Kullanici/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var kullanici = await _kullaniciService.GetByIdAsync(id);
            if (kullanici == null)
            {
                return NotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _kullaniciService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}