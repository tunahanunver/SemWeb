using SemWeb.Models;

namespace SemWebApi.Repositories.Interfaces
{
    public interface IAbonelikRepository : IRepository<Abonelik>
    {
        // Abonelik entity'sine özel methodlar
        Task<IEnumerable<Abonelik>> GetAbonelikByKullaniciIdAsync(int kullaniciId);
        Task<IEnumerable<Abonelik>> GetActiveAbonelikAsync();
        Task<IEnumerable<Abonelik>> GetExpiredAbonelikAsync();
        Task<IEnumerable<Abonelik>> GetAbonelikByTurAsync(string tur);
        Task<Abonelik> GetActiveAbonelikByKullaniciIdAsync(int kullaniciId);
    }
}