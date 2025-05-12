using Microsoft.EntityFrameworkCore;
using SemWeb.Models;
using SemWebApi.Data;
using SemWebApi.Repositories.Interfaces;

namespace SemWebApi.Repositories
{
    public class RandevuRepository : Repository<Randevu>, IRandevuRepository
    {
        public RandevuRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Randevu>> GetRandevuByKullaniciIdAsync(int kullaniciId)
        {
            return await _dbSet.Where(r => r.KullaniciId == kullaniciId)
                              .OrderBy(r => r.RandevuTarihi)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Randevu>> GetRandevuByDersIdAsync(int dersId)
        {
            return await _dbSet.Where(r => r.DersId == dersId)
                              .OrderBy(r => r.RandevuTarihi)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Randevu>> GetRandevuByTarihAsync(DateTime tarih)
        {
            return await _dbSet.Where(r => r.RandevuTarihi.Date == tarih.Date)
                              .OrderBy(r => r.RandevuTarihi)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Randevu>> GetFutureRandevuAsync()
        {
            return await _dbSet.Where(r => r.RandevuTarihi > DateTime.Now)
                              .OrderBy(r => r.RandevuTarihi)
                              .ToListAsync();
        }

        public async Task<bool> IsTimeSlotAvailableAsync(int dersId, DateTime baslangicZamani, DateTime bitisZamani)
        {
            // Verilen zaman aralığında aynı ders için başka randevu var mı?
            bool hasOverlap = await _dbSet.AnyAsync(r =>
                r.DersId == dersId &&
                ((baslangicZamani >= r.RandevuTarihi && baslangicZamani < r.BitisTarihi) ||
                 (bitisZamani > r.RandevuTarihi && bitisZamani <= r.BitisTarihi) ||
                 (baslangicZamani <= r.RandevuTarihi && bitisZamani >= r.BitisTarihi)));

            return !hasOverlap;
        }
    }
}