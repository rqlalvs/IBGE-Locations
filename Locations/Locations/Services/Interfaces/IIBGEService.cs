using Locations.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locations.Services.Interfaces
{
    public interface IIBGEService
    {
        public string RequestAll();
        public string RequestOne(int id);
    }
}
