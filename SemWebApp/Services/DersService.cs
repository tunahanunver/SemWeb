using SemWebApp.Models;

namespace SemWebApp.Services
{
    public class DersService : IDersService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;

        public DersService(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Ders>> GetAllAsync()
        {
            var endpoint = _configuration["ApiSettings:Endpoints:Ders"];
            return await _httpClientService.GetAsync<IEnumerable<Ders>>(endpoint);
        }

        public async Task<Ders> GetByIdAsync(int id)
        {
            var endpoint = $"{_configuration["ApiSettings:Endpoints:Ders"]}/{id}";
            return await _httpClientService.GetAsync<Ders>(endpoint);
        }

        public async Task<Ders> CreateAsync(Ders entity)
        {
            var endpoint = _configuration["ApiSettings:Endpoints:Ders"];
            return await _httpClientService.PostAsync<Ders>(endpoint, entity);
        }

        public async Task<Ders> UpdateAsync(int id, Ders entity)
        {
            var endpoint = $"{_configuration["ApiSettings:Endpoints:Ders"]}/{id}";
            return await _httpClientService.PutAsync<Ders>(endpoint, entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var endpoint = $"{_configuration["ApiSettings:Endpoints:Ders"]}/{id}";
            return await _httpClientService.DeleteAsync(endpoint);
        }
    }
}
