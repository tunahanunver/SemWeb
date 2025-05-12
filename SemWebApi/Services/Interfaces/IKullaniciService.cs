using SemWeb.Models;

namespace SemWebApi.Services.Interfaces
{
    public interface IKullaniciService
    {
        Task<IEnumerable<Kullanici>> GetAllAsync();
        Task<Kullanici> GetByIdAsync(int id);
        Task<Kullanici> CreateAsync(Kullanici kullanici);
        Task<Kullanici> UpdateAsync(int id, Kullanici kullanici);
        Task DeleteAsync(int id);
        Task<Kullanici> GetByEmailAsync(string email);
        // Diğer servis methodları...
    }
}