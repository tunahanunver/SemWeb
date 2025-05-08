using SemWebApp.Models;

namespace SemWebApp.Services
{
    public class AbonelikService : IAbonelikService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;

        public AbonelikService(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Abonelik>> GetAllAsync()
        {
            var endpoint = _configuration["ApiSettings:Endpoints:Abonelik"];
            return await _httpClientService.GetAsync<IEnumerable<Abonelik>>(endpoint);
        }

        public async Task<Abonelik> GetByIdAsync(int id)
        {
            var endpoint = $"{_configuration["ApiSettings:Endpoints:Abonelik"]}/{id}";
            return await _httpClientService.GetAsync<Abonelik>(endpoint);
        }

        public async Task<Abonelik> CreateAsync(Abonelik entity)
        {
            var endpoint = _configuration["ApiSettings:Endpoints:Abonelik"];
            return await _httpClientService.PostAsync<Abonelik>(endpoint, entity);
        }

        public async Task<Abonelik> UpdateAsync(int id, Abonelik entity)
        {
            var endpoint = $"{_configuration["ApiSettings:Endpoints:Abonelik"]}/{id}";
            return await _httpClientService.PutAsync<Abonelik>(endpoint, entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var endpoint = $"{_configuration["ApiSettings:Endpoints:Abonelik"]}/{id}";
            return await _httpClientService.DeleteAsync(endpoint);
        }
    }
}
