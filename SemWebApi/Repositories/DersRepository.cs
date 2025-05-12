using Microsoft.EntityFrameworkCore;
using SemWeb.Models;
using SemWebApi.Data;
using SemWebApi.Repositories.Interfaces;

namespace SemWebApi.Repositories
{
    public class DersRepository : Repository<Ders>, IDersRepository
    {
        public DersRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ders>> GetActiveCoursesAsync()
        {
            return await _dbSet.Where(d => d.AktifMi).ToListAsync();
        }

        public async Task<IEnumerable<Ders>> GetDersByEgitmenIdAsync(int egitmenId)
        {
            return await _dbSet.Where(d => d.EgitmenId == egitmenId).ToListAsync();
        }

        public async Task<IEnumerable<Ders>> GetDersByTypeAsync(string dersTipi)
        {
            return await _dbSet.Where(d => d.DersTipi == dersTipi).ToListAsync();
        }
    }
}