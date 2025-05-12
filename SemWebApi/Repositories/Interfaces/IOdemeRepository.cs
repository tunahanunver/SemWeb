using SemWeb.Models;

namespace SemWebApi.Repositories.Interfaces
{
    public interface IOdemeRepository : IRepository<Odeme>
    {
        // Odeme entity'sine özel methodlar
        Task<IEnumerable<Odeme>> GetOdemeByKullaniciIdAsync(int kullaniciId);
        Task<IEnumerable<Odeme>> GetOdemeByAbonelikIdAsync(int abonelikId);
        Task<IEnumerable<Odeme>> GetOdemeByTarihArasiAsync(DateTime baslangic, DateTime bitis);
        Task<IEnumerable<Odeme>> GetOdemeByDurumAsync(string durum);
        Task<decimal> GetTotalOdemeByDateRangeAsync(DateTime baslangic, DateTime bitis);
    }
}