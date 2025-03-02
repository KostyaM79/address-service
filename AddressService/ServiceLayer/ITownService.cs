using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.ServiceLayer
{
    public interface ITownService
    {
        int Add(int districtId, string townName, int townStatusId);
    }
}
