using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IpController : ControllerBase
    {
        private readonly IUserRepository _context;
        private readonly IIpAddressRepository _ipRepository;
        private readonly ISpeedTestRepository _speedTestRepository;

        public IpController(IUserRepository context, IIpAddressRepository ipRepository, ISpeedTestRepository speedTestRepository)
        {
            _context = context;
            _ipRepository = ipRepository;
            _speedTestRepository = speedTestRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.GetUsersAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            var kbsec = await _speedTestRepository.CheckSpeed();
            var ip =  await _ipRepository.GetIpResultsAsync();
            if(user != null)
            {
            user.internetServiceProvider = ip.InternetServiceProvider;
            user.ipAddress = ip.IpAddress;
            user.statusMessage = ip.StatusMessage;
            user.speed = kbsec;
            await _context.CreateUserAsync(user);
            }
            return NoContent();
        }
    }
}