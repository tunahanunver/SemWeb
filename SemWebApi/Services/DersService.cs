using SemWeb.Models;
using SemWebApi.Repositories.Interfaces;
using SemWebApi.Services.Interfaces;

namespace SemWebApi.Services
{
    public class DersService : IDersService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Ders>> GetAllAsync()
        {
            return await _unitOfWork.Dersler.GetAllAsync();
        }

        public async Task<Ders> GetByIdAsync(int id)
        {
            return await _unitOfWork.Dersler.GetByIdAsync(id);
        }

        public async Task<Ders> CreateAsync(Ders ders)
        {
            await _unitOfWork.Dersler.AddAsync(ders);
            await _unitOfWork.CompleteAsync();
            return ders;
        }

        public async Task<Ders> UpdateAsync(int id, Ders ders)
        {
            var existingDers = await _unitOfWork.Dersler.GetByIdAsync(id);
            if (existingDers == null)
                return null;

            // Update existingDers properties
            existingDers.DersAdi = ders.DersAdi;
            existingDers.Aciklama = ders.Aciklama;
            existingDers.DersTipi = ders.DersTipi;
            existingDers.EgitmenId = ders.EgitmenId;
            existingDers.AktifMi = ders.AktifMi;
            existingDers.Kapasite = ders.Kapasite;
            // Diğer property'ler modeldeki alanlara göre eklenebilir

            await _unitOfWork.Dersler.UpdateAsync(existingDers);
            await _unitOfWork.CompleteAsync();
            return existingDers;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Dersler.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<Ders>> GetActiveCoursesAsync()
        {
            return await _unitOfWork.Dersler.GetActiveCoursesAsync();
        }

        public async Task<IEnumerable<Ders>> GetDersByEgitmenIdAsync(int egitmenId)
        {
            return await _unitOfWork.Dersler.GetDersByEgitmenIdAsync(egitmenId);
        }

        public async Task<IEnumerable<Ders>> GetDersByTypeAsync(string dersTipi)
        {
            return await _unitOfWork.Dersler.GetDersByTypeAsync(dersTipi);
        }
    }
}