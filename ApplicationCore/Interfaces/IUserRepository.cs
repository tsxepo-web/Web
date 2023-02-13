using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetByIdAsync();
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(int Id);

    }
}