using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;

namespace Infrastructure.Repositories
{
    public class SpeedTestRepository : ISpeedTestRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SpeedTestRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;   
        }
        public async Task<double> CheckSpeed()
        {
            var url = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Sir_Joseph_Noel_Paton_-_The_Quarrel_of_Oberon_and_Titania_-_Google_Art_Project_2.jpg/578px-Sir_Joseph_Noel_Paton_-_The_Quarrel_of_Oberon_and_Titania_-_Google_Art_Project_2.jpg";
            var client = _httpClientFactory.CreateClient();
            double starttime = Environment.TickCount;
            var response = await client.GetAsync(url);
            double endtime = Environment.TickCount;

            double secs = Math.Floor(endtime - starttime) / 1000;
            double secs2 = Math.Round(secs, 0);
            double kbsec = Math.Round(1024 / secs);

            return kbsec;
        }
    }
}