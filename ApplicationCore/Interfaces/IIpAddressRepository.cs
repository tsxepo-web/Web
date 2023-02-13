using ApplicationCore.DTO;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IIpAddressRepository
    {
        public Task<ResultsObject> GetIpResultsAsync();
    }
}
