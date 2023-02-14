using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ISpeedTestRepository
    {
        public Task<double> CheckSpeed();
    }
}