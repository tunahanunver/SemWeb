using SemWebApp.Models;

namespace SemWebApp.Services
{
    public class KullaniciService : IKullaniciService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;

        public KullaniciService(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Kullanici>> GetAllAsync()
        {
            var endpoint = _configuration["ApiSettings:Endpoints:Kullanici"];
            return await _httpClientService.GetAsync<IEnumerable<Kullanici>>(endpoint);
        }

        public async Task<Kullanici> GetByIdAsync(int id)
        {
            var endpoint = $"{_configuration["ApiSettings:Endpoints:Kullanici"]}/{id}";
            return await _httpClientService.GetAsync<Kullanici>(endpoint);
        }

        public async Task<Kullanici> CreateAsync(Kullanici entity)
        {
            var endpoint = _configuration["ApiSettings:Endpoints:Kullanici"];
            return await _httpClientService.PostAsync<Kullanici>(endpoint, entity);
        }

        public async Task<Kullanici> UpdateAsync(int id, Kullanici entity)
        {
            var endpoint = $"{_configuration["ApiSettings:Endpoints:Kullanici"]}/{id}";
            return await _httpClientService.PutAsync<Kullanici>(endpoint, entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var endpoint = $"{_configuration["ApiSettings:Endpoints:Kullanici"]}/{id}";
            return await _httpClientService.DeleteAsync(endpoint);
        }
    }
}
