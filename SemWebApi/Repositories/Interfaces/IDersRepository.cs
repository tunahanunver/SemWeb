using SemWeb.Models;

namespace SemWebApi.Repositories.Interfaces
{
    public interface IDersRepository : IRepository<Ders>
    {
        // Ders entity'sine özel methodlar
        Task<IEnumerable<Ders>> GetActiveCoursesAsync();
        Task<IEnumerable<Ders>> GetDersByEgitmenIdAsync(int egitmenId);
        Task<IEnumerable<Ders>> GetDersByTypeAsync(string dersTipi);
    }
}