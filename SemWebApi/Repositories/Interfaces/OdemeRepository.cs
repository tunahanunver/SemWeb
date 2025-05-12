using Microsoft.EntityFrameworkCore;
using SemWeb.Models;
using SemWebApi.Data;
using SemWebApi.Repositories.Interfaces;

namespace SemWebApi.Repositories
{
    public class OdemeRepository : Repository<Odeme>, IOdemeRepository
    {
        public OdemeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Odeme>> GetOdemeByKullaniciIdAsync(int kullaniciId)
        {
            return await _dbSet.Where(o => o.KullaniciId == kullaniciId)
                              .OrderByDescending(o => o.OdemeTarihi)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Odeme>> GetOdemeByAbonelikIdAsync(int abonelikId)
        {
            return await _dbSet.Where(o => o.AbonelikId == abonelikId)
                              .OrderByDescending(o => o.OdemeTarihi)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Odeme>> GetOdemeByTarihArasiAsync(DateTime baslangic, DateTime bitis)
        {
            return await _dbSet.Where(o => o.OdemeTarihi >= baslangic && o.OdemeTarihi <= bitis)
                              .OrderByDescending(o => o.OdemeTarihi)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Odeme>> GetOdemeByDurumAsync(string durum)
        {
            return await _dbSet.Where(o => o.OdemeDurumu == durum)
                              .OrderByDescending(o => o.OdemeTarihi)
                              .ToListAsync();
        }

        public async Task<decimal> GetTotalOdemeByDateRangeAsync(DateTime baslangic, DateTime bitis)
        {
            return await _dbSet.Where(o => o.OdemeTarihi >= baslangic &&
                                 o.OdemeTarihi <= bitis &&
                                 o.OdemeDurumu == "Başarılı")
                              .SumAsync(o => o.Tutar);
        }
    }
}