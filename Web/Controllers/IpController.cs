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

        public IpController(IUserRepository context, IIpAddressRepository ipRepository)
        {
            _context = context;
            _ipRepository = ipRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.GetUsersAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _context.CreateUserAsync(user);
            var ip =  await _ipRepository.GetIpResultsAsync();
            if (user != null)
            {
                user.internetServiceProvider = ip.internetServiceProvider;
                user.IpAddress = ip.IpAddress;
                user.statusMessage = ip.statusMessage;
            }

            return NoContent();
        }
    }
}