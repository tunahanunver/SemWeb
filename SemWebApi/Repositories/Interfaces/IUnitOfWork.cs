namespace SemWebApi.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IKullaniciRepository Kullanicilar { get; }
        IDersRepository Dersler { get; }
        IRandevuRepository Randevular { get; }
        IAbonelikRepository Abonelikler { get; }
        IOdemeRepository Odemeler { get; }

        Task<int> CompleteAsync();
    }
}