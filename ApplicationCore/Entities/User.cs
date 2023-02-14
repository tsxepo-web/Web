using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int Id {get; set;}
        public string? statusMessage {get; set;}
        public string? internetServiceProvider {get; set;}
        public string? ipAddress {get; set;}
        public double speed {get; set;}
    }
}