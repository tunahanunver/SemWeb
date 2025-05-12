using SemWeb.Models;
using SemWebApi.Repositories.Interfaces;
using SemWebApi.Services.Interfaces;

namespace SemWebApi.Services
{
    public class AbonelikService : IAbonelikService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AbonelikService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Abonelik>> GetAllAsync()
        {
            return await _unitOfWork.Abonelikler.GetAllAsync();
        }

        public async Task<Abonelik> GetByIdAsync(int id)
        {
            return await _unitOfWork.Abonelikler.GetByIdAsync(id);
        }

        public async Task<Abonelik> CreateAsync(Abonelik abonelik)
        {
            // Kullanıcının aktif aboneliği var mı kontrolü
            var activeAbonelik = await _unitOfWork.Abonelikler.GetActiveAbonelikByKullaniciIdAsync(abonelik.KullaniciId);

            // Eğer aynı türde aktif abonelik varsa, tarih kontrolü
            if (activeAbonelik != null && activeAbonelik.Tur == abonelik.Tur)
            {
                throw new InvalidOperationException("Kullanıcının bu türde aktif bir aboneliği zaten var.");
            }

            await _unitOfWork.Abonelikler.AddAsync(abonelik);
            await _unitOfWork.CompleteAsync();
            return abonelik;
        }

        public async Task<Abonelik> UpdateAsync(int id, Abonelik abonelik)
        {
            var existingAbonelik = await _unitOfWork.Abonelikler.GetByIdAsync(id);
            if (existingAbonelik == null)
                return null;

            // Update existingAbonelik properties
            existingAbonelik.KullaniciId = abonelik.KullaniciId;
            existingAbonelik.Tur = abonelik.Tur;
            existingAbonelik.BaslangicTarihi = abonelik.BaslangicTarihi;
            existingAbonelik.BitisTarihi = abonelik.BitisTarihi;
            existingAbonelik.Fiyat = abonelik.Fiyat;
            existingAbonelik.AktifMi = abonelik.AktifMi;
            // Diğer property'ler modeldeki alanlara göre eklenebilir

            await _unitOfWork.Abonelikler.UpdateAsync(existingAbonelik);
            await _unitOfWork.CompleteAsync();
            return existingAbonelik;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Abonelikler.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<Abonelik>> GetAbonelikByKullaniciIdAsync(int kullaniciId)
        {
            return await _unitOfWork.Abonelikler.GetAbonelikByKullaniciIdAsync(kullaniciId);
        }

        public async Task<IEnumerable<Abonelik>> GetActiveAbonelikAsync()
        {
            return await _unitOfWork.Abonelikler.GetActiveAbonelikAsync();
        }

        public async Task<IEnumerable<Abonelik>> GetExpiredAbonelikAsync()
        {
            return await _unitOfWork.Abonelikler.GetExpiredAbonelikAsync();
        }

        public async Task<IEnumerable<Abonelik>> GetAbonelikByTurAsync(string tur)
        {
            return await _unitOfWork.Abonelikler.GetAbonelikByTurAsync(tur);
        }

        public async Task<Abonelik> GetActiveAbonelikByKullaniciIdAsync(int kullaniciId)
        {
            return await _unitOfWork.Abonelikler.GetActiveAbonelikByKullaniciIdAsync(kullaniciId);
        }

        public async Task<Abonelik> YenileAbonelikAsync(int abonelikId, int ayEkle)
        {
            var abonelik = await _unitOfWork.Abonelikler.GetByIdAsync(abonelikId);
            if (abonelik == null)
                return null;

            // Eğer abonelik aktif değilse, bugünden başlat
            if (!abonelik.AktifMi || abonelik.BitisTarihi < DateTime.Today)
            {
                abonelik.BaslangicTarihi = DateTime.Today;
                abonelik.BitisTarihi = DateTime.Today.AddMonths(ayEkle);
            }
            else // Aktif aboneliğin bitiş tarihini uzat
            {
                abonelik.BitisTarihi = abonelik.BitisTarihi.AddMonths(ayEkle);
            }

            abonelik.AktifMi = true;

            await _unitOfWork.Abonelikler.UpdateAsync(abonelik);
            await _unitOfWork.CompleteAsync();
            return abonelik;
        }
    }
}