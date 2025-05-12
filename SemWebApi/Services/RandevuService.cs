using SemWeb.Models;
using SemWebApi.Repositories.Interfaces;
using SemWebApi.Services.Interfaces;

namespace SemWebApi.Services
{
    public class RandevuService : IRandevuService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RandevuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Randevu>> GetAllAsync()
        {
            return await _unitOfWork.Randevular.GetAllAsync();
        }

        public async Task<Randevu> GetByIdAsync(int id)
        {
            return await _unitOfWork.Randevular.GetByIdAsync(id);
        }

        public async Task<Randevu> CreateAsync(Randevu randevu)
        {
            // Zaman çakışması kontrolü
            bool isAvailable = await _unitOfWork.Randevular.IsTimeSlotAvailableAsync(
                randevu.DersId, randevu.RandevuTarihi, randevu.BitisTarihi);

            if (!isAvailable)
                throw new InvalidOperationException("Bu zaman diliminde ders zaten dolu.");

            await _unitOfWork.Randevular.AddAsync(randevu);
            await _unitOfWork.CompleteAsync();
            return randevu;
        }

        public async Task<Randevu> UpdateAsync(int id, Randevu randevu)
        {
            var existingRandevu = await _unitOfWork.Randevular.GetByIdAsync(id);
            if (existingRandevu == null)
                return null;

            // Eğer zaman değiştiyse, çakışma kontrolü
            if (existingRandevu.RandevuTarihi != randevu.RandevuTarihi ||
                existingRandevu.BitisTarihi != randevu.BitisTarihi ||
                existingRandevu.DersId != randevu.DersId)
            {
                bool isAvailable = await _unitOfWork.Randevular.IsTimeSlotAvailableAsync(
                    randevu.DersId, randevu.RandevuTarihi, randevu.BitisTarihi);

                if (!isAvailable)
                    throw new InvalidOperationException("Bu zaman diliminde ders zaten dolu.");
            }

            // Update existingRandevu properties
            existingRandevu.KullaniciId = randevu.KullaniciId;
            existingRandevu.DersId = randevu.DersId;
            existingRandevu.RandevuTarihi = randevu.RandevuTarihi;
            existingRandevu.BitisTarihi = randevu.BitisTarihi;
            existingRandevu.Durum = randevu.Durum;
            // Diğer property'ler modeldeki alanlara göre eklenebilir

            await _unitOfWork.Randevular.UpdateAsync(existingRandevu);
            await _unitOfWork.CompleteAsync();
            return existingRandevu;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Randevular.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<Randevu>> GetRandevuByKullaniciIdAsync(int kullaniciId)
        {
            return await _unitOfWork.Randevular.GetRandevuByKullaniciIdAsync(kullaniciId);
        }

        public async Task<IEnumerable<Randevu>> GetRandevuByDersIdAsync(int dersId)
        {
            return await _unitOfWork.Randevular.GetRandevuByDersIdAsync(dersId);
        }

        public async Task<IEnumerable<Randevu>> GetRandevuByTarihAsync(DateTime tarih)
        {
            return await _unitOfWork.Randevular.GetRandevuByTarihAsync(tarih);
        }

        public async Task<IEnumerable<Randevu>> GetFutureRandevuAsync()
        {
            return await _unitOfWork.Randevular.GetFutureRandevuAsync();
        }

        public async Task<bool> IsTimeSlotAvailableAsync(int dersId, DateTime baslangicZamani, DateTime bitisZamani)
        {
            return await _unitOfWork.Randevular.IsTimeSlotAvailableAsync(dersId, baslangicZamani, bitisZamani);
        }
    }
}