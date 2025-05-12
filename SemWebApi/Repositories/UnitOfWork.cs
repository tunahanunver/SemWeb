using SemWebApi.Data;
using SemWebApi.Repositories.Interfaces;

namespace SemWebApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IKullaniciRepository Kullanicilar { get; private set; }
        public IDersRepository Dersler { get; private set; }
        public IRandevuRepository Randevular { get; private set; }
        public IAbonelikRepository Abonelikler { get; private set; }
        public IOdemeRepository Odemeler { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Kullanicilar = new KullaniciRepository(_context);
            Dersler = new DersRepository(_context);
            Randevular = new RandevuRepository(_context);
            Abonelikler = new AbonelikRepository(_context);
            Odemeler = new OdemeRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}