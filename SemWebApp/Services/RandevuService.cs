using SemWebApp.Models;

namespace SemWebApp.Services
{
    public class RandevuService : IRandevuService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;

        public RandevuService(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Randevu>> GetAllAsync()
        {
            var endpoint = _configuration["ApiSettings:Endpoints:Randevu"];
            return await _httpClientService.GetAsync<IEnumerable<Randevu>>(endpoint);
        }

        public async Task<Randevu> GetByIdAsync(int id)
        {
            var endpoint = $"{_configuration["ApiSettings:Endpoints:Randevu"]}/{id}";
            return await _httpClientService.GetAsync<Randevu>(endpoint);
        }

        public async Task<Randevu> CreateAsync(Randevu entity)
        {
            var endpoint = _configuration["ApiSettings:Endpoints:Randevu"];
            return await _httpClientService.PostAsync<Randevu>(endpoint, entity);
        }

        public async Task<Randevu> UpdateAsync(int id, Randevu entity)
        {
            var endpoint = $"{_configuration["ApiSettings:Endpoints:Randevu"]}/{id}";
            return await _httpClientService.PutAsync<Randevu>(endpoint, entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var endpoint = $"{_configuration["ApiSettings:Endpoints:Randevu"]}/{id}";
            return await _httpClientService.DeleteAsync(endpoint);
        }
    }
}
