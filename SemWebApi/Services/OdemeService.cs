using SemWeb.Models;
using SemWebApi.Repositories.Interfaces;
using SemWebApi.Services.Interfaces;

namespace SemWebApi.Services
{
    public class OdemeService : IOdemeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OdemeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Odeme>> GetAllAsync()
        {
            return await _unitOfWork.Odemeler.GetAllAsync();
        }

        public async Task<Odeme> GetByIdAsync(int id)
        {
            return await _unitOfWork.Odemeler.GetByIdAsync(id);
        }

        public async Task<Odeme> CreateAsync(Odeme odeme)
        {
            await _unitOfWork.Odemeler.AddAsync(odeme);
            await _unitOfWork.CompleteAsync();
            return odeme;
        }

        public async Task<Odeme> UpdateAsync(int id, Odeme odeme)
        {
            var existingOdeme = await _unitOfWork.Odemeler.GetByIdAsync(id);
            if (existingOdeme == null)
                return null;

            // Update existingOdeme properties
            existingOdeme.KullaniciId = odeme.KullaniciId;
            existingOdeme.AbonelikId = odeme.AbonelikId;
            existingOdeme.OdemeTarihi = odeme.OdemeTarihi;
            existingOdeme.Tutar = odeme.Tutar;
            existingOdeme.OdemeTipi = odeme.OdemeTipi;
            existingOdeme.OdemeDurumu = odeme.OdemeDurumu;
            // Diğer property'ler modeldeki alanlara göre eklenebilir

            await _unitOfWork.Odemeler.UpdateAsync(existingOdeme);
            await _unitOfWork.CompleteAsync();
            return existingOdeme;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Odemeler.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<Odeme>> GetOdemeByKullaniciIdAsync(int kullaniciId)
        {
            return await _unitOfWork.Odemeler.GetOdemeByKullaniciIdAsync(kullaniciId);
        }

        public async Task<IEnumerable<Odeme>> GetOdemeByAbonelikIdAsync(int abonelikId)
        {
            return await _unitOfWork.Odemeler.GetOdemeByAbonelikIdAsync(abonelikId);
        }

        public async Task<IEnumerable<Odeme>> GetOdemeByTarihArasiAsync(DateTime baslangic, DateTime bitis)
        {
            return await _unitOfWork.Odemeler.GetOdemeByTarihArasiAsync(baslangic, bitis);
        }

        public async Task<IEnumerable<Odeme>> GetOdemeByDurumAsync(string durum)
        {
            return await _unitOfWork.Odemeler.GetOdemeByDurumAsync(durum);
        }

        public async Task<decimal> GetTotalOdemeByDateRangeAsync(DateTime baslangic, DateTime bitis)
        {
            return await _unitOfWork.Odemeler.GetTotalOdemeByDateRangeAsync(baslangic, bitis);
        }

        public async Task<Odeme> ProcessPaymentAsync(Odeme odeme)
        {
            // Burada gerçek ödeme işlemi için entegrasyon yapılabilir
            // Örnek: PayTR, iyzico, Paynet vb. entegrasyonları

            // Bu örnek için basitçe ödemeyi başarılı kabul edelim
            odeme.OdemeDurumu = "Başarılı";
            odeme.OdemeTarihi = DateTime.Now;

            await _unitOfWork.Odemeler.AddAsync(odeme);

            // Eğer abonelik varsa, aboneliği aktifleştir
            if (odeme.AbonelikId.HasValue)
            {
                var abonelik = await _unitOfWork.Abonelikler.GetByIdAsync(odeme.AbonelikId.Value);
                if (abonelik != null)
                {
                    abonelik.AktifMi = true;
                    await _unitOfWork.Abonelikler.UpdateAsync(abonelik);
                }
            }

            await _unitOfWork.CompleteAsync();
            return odeme;
        }
    }
}