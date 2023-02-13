using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;

namespace Infrastructure
{
    public class SpeedTestContext: DbContext
    {
        public SpeedTestContext(DbContextOptions<SpeedTestContext> options): base(options){}
        
        public DbSet<User> Users {get; set;} = null!;
    }
}