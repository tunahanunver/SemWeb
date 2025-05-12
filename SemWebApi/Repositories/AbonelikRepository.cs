using Microsoft.EntityFrameworkCore;
using SemWeb.Models;
using SemWebApi.Data;
using SemWebApi.Repositories.Interfaces;

namespace SemWebApi.Repositories
{
    public class AbonelikRepository : Repository<Abonelik>, IAbonelikRepository
    {
        public AbonelikRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Abonelik>> GetAbonelikByKullaniciIdAsync(int kullaniciId)
        {
            return await _dbSet.Where(a => a.KullaniciId == kullaniciId)
                              .OrderByDescending(a => a.BaslangicTarihi)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Abonelik>> GetActiveAbonelikAsync()
        {
            var today = DateTime.Today;
            return await _dbSet.Where(a => a.AktifMi && a.BitisTarihi >= today)
                              .OrderBy(a => a.BitisTarihi)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Abonelik>> GetExpiredAbonelikAsync()
        {
            var today = DateTime.Today;
            return await _dbSet.Where(a => a.BitisTarihi < today || !a.AktifMi)
                              .OrderByDescending(a => a.BitisTarihi)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Abonelik>> GetAbonelikByTurAsync(string tur)
        {
            return await _dbSet.Where(a => a.Tur == tur)
                              .OrderByDescending(a => a.BaslangicTarihi)
                              .ToListAsync();
        }

        public async Task<Abonelik> GetActiveAbonelikByKullaniciIdAsync(int kullaniciId)
        {
            var today = DateTime.Today;
            return await _dbSet.Where(a => a.KullaniciId == kullaniciId &&
                                   a.AktifMi &&
                                   a.BitisTarihi >= today)
                              .OrderByDescending(a => a.BitisTarihi)
                              .FirstOrDefaultAsync();
        }
    }
}