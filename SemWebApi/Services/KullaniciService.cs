using SemWeb.Models;
using SemWebApi.Repositories.Interfaces;
using SemWebApi.Services.Interfaces;

namespace SemWebApi.Services
{
    public class KullaniciService : IKullaniciService
    {
        private readonly IUnitOfWork _unitOfWork;

        public KullaniciService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Kullanici>> GetAllAsync()
        {
            return await _unitOfWork.Kullanicilar.GetAllAsync();
        }

        public async Task<Kullanici> GetByIdAsync(int id)
        {
            return await _unitOfWork.Kullanicilar.GetByIdAsync(id);
        }

        public async Task<Kullanici> CreateAsync(Kullanici kullanici)
        {
            await _unitOfWork.Kullanicilar.AddAsync(kullanici);
            await _unitOfWork.CompleteAsync();
            return kullanici;
        }

        public async Task<Kullanici> UpdateAsync(int id, Kullanici kullanici)
        {
            var existingKullanici = await _unitOfWork.Kullanicilar.GetByIdAsync(id);
            if (existingKullanici == null)
                return null;

            // Update existingKullanici properties
            existingKullanici.Ad = kullanici.Ad;
            existingKullanici.Soyad = kullanici.Soyad;
            // Update other properties...

            await _unitOfWork.Kullanicilar.UpdateAsync(existingKullanici);
            await _unitOfWork.CompleteAsync();
            return existingKullanici;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Kullanicilar.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<Kullanici> GetByEmailAsync(string email)
        {
            return await _unitOfWork.Kullanicilar.GetByEmailAsync(email);
        }
    }
}