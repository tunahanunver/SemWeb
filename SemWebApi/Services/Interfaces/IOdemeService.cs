using SemWeb.Models;

namespace SemWebApi.Services.Interfaces
{
    public interface IOdemeService
    {
        Task<IEnumerable<Odeme>> GetAllAsync();
        Task<Odeme> GetByIdAsync(int id);
        Task<Odeme> CreateAsync(Odeme odeme);
        Task<Odeme> UpdateAsync(int id, Odeme odeme);
        Task DeleteAsync(int id);
        Task<IEnumerable<Odeme>> GetOdemeByKullaniciIdAsync(int kullaniciId);
        Task<IEnumerable<Odeme>> GetOdemeByAbonelikIdAsync(int abonelikId);
        Task<IEnumerable<Odeme>> GetOdemeByTarihArasiAsync(DateTime baslangic, DateTime bitis);
        Task<IEnumerable<Odeme>> GetOdemeByDurumAsync(string durum);
        Task<decimal> GetTotalOdemeByDateRangeAsync(DateTime baslangic, DateTime bitis);
        Task<Odeme> ProcessPaymentAsync(Odeme odeme);
    }
}