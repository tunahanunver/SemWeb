using SemWeb.Models;

namespace SemWebApi.Repositories.Interfaces
{
    public interface IRandevuRepository : IRepository<Randevu>
    {
        // Randevu entity'sine özel methodlar
        Task<IEnumerable<Randevu>> GetRandevuByKullaniciIdAsync(int kullaniciId);
        Task<IEnumerable<Randevu>> GetRandevuByDersIdAsync(int dersId);
        Task<IEnumerable<Randevu>> GetRandevuByTarihAsync(DateTime tarih);
        Task<IEnumerable<Randevu>> GetFutureRandevuAsync();
        Task<bool> IsTimeSlotAvailableAsync(int dersId, DateTime baslangicZamani, DateTime bitisZamani);
    }
}