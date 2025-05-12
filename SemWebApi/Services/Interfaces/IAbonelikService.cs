using SemWeb.Models;

namespace SemWebApi.Services.Interfaces
{
    public interface IAbonelikService
    {
        Task<IEnumerable<Abonelik>> GetAllAsync();
        Task<Abonelik> GetByIdAsync(int id);
        Task<Abonelik> CreateAsync(Abonelik abonelik);
        Task<Abonelik> UpdateAsync(int id, Abonelik abonelik);
        Task DeleteAsync(int id);
        Task<IEnumerable<Abonelik>> GetAbonelikByKullaniciIdAsync(int kullaniciId);
        Task<IEnumerable<Abonelik>> GetActiveAbonelikAsync();
        Task<IEnumerable<Abonelik>> GetExpiredAbonelikAsync();
        Task<IEnumerable<Abonelik>> GetAbonelikByTurAsync(string tur);
        Task<Abonelik> GetActiveAbonelikByKullaniciIdAsync(int kullaniciId);
        Task<Abonelik> YenileAbonelikAsync(int abonelikId, int ayEkle);
    }
}