using ApplicationCore.DTO;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Infrastructure.Repositories
{
    public class IpAddressRepository : IIpAddressRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public IpAddressRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory= httpClientFactory;
        }

        public async Task<ResultsObject> GetIpResultsAsync()
        {
            string url = $"http://ip-api.com/json/?fields";
            var ipResults = new ResultsObject();
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var jsonRespose = await response.Content.ReadAsStringAsync();
            var ipResponse = JsonConvert.DeserializeObject<IpResponse>(jsonRespose);
            if(ipResponse != null)
            {
                ipResults.statusMessage = ipResponse.status;
                ipResults.internetServiceProvider = ipResponse.isp;
                ipResults.IpAddress = ipResponse.query;
            }
            return ipResults;
        }
    }
}
