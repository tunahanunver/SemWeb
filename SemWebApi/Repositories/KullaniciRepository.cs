using Microsoft.EntityFrameworkCore;
using SemWeb.Models;
using SemWebApi.Data;
using SemWebApi.Repositories.Interfaces;

namespace SemWebApi.Repositories
{
    public class KullaniciRepository : Repository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Kullanici> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(k => k.Email == email);
        }

        public async Task<IEnumerable<Kullanici>> GetActiveUsersAsync()
        {
            return await _dbSet.Where(k => k.Aktif).ToListAsync();
        }
    }
}