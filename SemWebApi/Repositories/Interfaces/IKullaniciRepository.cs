using SemWeb.Models;

namespace SemWebApi.Repositories.Interfaces
{
    public interface IKullaniciRepository : IRepository<Kullanici>
    {
        // Kullanici entity'sine özel methodlar
        Task<Kullanici> GetByEmailAsync(string email);
        Task<IEnumerable<Kullanici>> GetActiveUsersAsync();
        // Diğer özel methodlar...
    }
}