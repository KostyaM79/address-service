using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.ServiceLayer
{
    public interface IStreetService
    {
        int Add(int townId, string streetName, int streetTypeId);
    }
}
