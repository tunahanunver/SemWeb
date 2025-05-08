using SemWebApp.Models;

namespace SemWebApp.Services
{
    public class OdemeService : IOdemeService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;

        public OdemeService(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Odeme>> GetAllAsync()
        {
            var endpoint = _configuration["ApiSettings:Endpoints:Odeme"];
            return await _httpClientService.GetAsync<IEnumerable<Odeme>>(endpoint);
        }

        public async Task<Odeme> GetByIdAsync(int id)
        {
            var endpoint = $"{_configuration["ApiSettings:Endpoints:Odeme"]}/{id}";
            return await _httpClientService.GetAsync<Odeme>(endpoint);
        }

        public async Task<Odeme> CreateAsync(Odeme entity)
        {
            var endpoint = _configuration["ApiSettings:Endpoints:Odeme"];
            return await _httpClientService.PostAsync<Odeme>(endpoint, entity);
        }

        public async Task<Odeme> UpdateAsync(int id, Odeme entity)
        {
            var endpoint = $"{_configuration["ApiSettings:Endpoints:Odeme"]}/{id}";
            return await _httpClientService.PutAsync<Odeme>(endpoint, entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var endpoint = $"{_configuration["ApiSettings:Endpoints:Odeme"]}/{id}";
            return await _httpClientService.DeleteAsync(endpoint);
        }
    }
}
