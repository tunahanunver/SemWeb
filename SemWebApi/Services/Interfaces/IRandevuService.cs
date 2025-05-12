using SemWeb.Models;

namespace SemWebApi.Services.Interfaces
{
    public interface IRandevuService
    {
        Task<IEnumerable<Randevu>> GetAllAsync();
        Task<Randevu> GetByIdAsync(int id);
        Task<Randevu> CreateAsync(Randevu randevu);
        Task<Randevu> UpdateAsync(int id, Randevu randevu);
        Task DeleteAsync(int id);
        Task<IEnumerable<Randevu>> GetRandevuByKullaniciIdAsync(int kullaniciId);
        Task<IEnumerable<Randevu>> GetRandevuByDersIdAsync(int dersId);
        Task<IEnumerable<Randevu>> GetRandevuByTarihAsync(DateTime tarih);
        Task<IEnumerable<Randevu>> GetFutureRandevuAsync();
        Task<bool> IsTimeSlotAvailableAsync(int dersId, DateTime baslangicZamani, DateTime bitisZamani);
    }
}