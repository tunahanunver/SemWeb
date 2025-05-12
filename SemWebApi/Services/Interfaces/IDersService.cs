using SemWeb.Models;

namespace SemWebApi.Services.Interfaces
{
    public interface IDersService
    {
        Task<IEnumerable<Ders>> GetAllAsync();
        Task<Ders> GetByIdAsync(int id);
        Task<Ders> CreateAsync(Ders ders);
        Task<Ders> UpdateAsync(int id, Ders ders);
        Task DeleteAsync(int id);
        Task<IEnumerable<Ders>> GetActiveCoursesAsync();
        Task<IEnumerable<Ders>> GetDersByEgitmenIdAsync(int egitmenId);
        Task<IEnumerable<Ders>> GetDersByTypeAsync(string dersTipi);
    }
}