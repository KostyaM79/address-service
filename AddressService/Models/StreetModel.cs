using AddressService.Common;
using AddressService.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Models
{
    public class StreetModel : StreetModelBase
    {
        public int AddNewStreet(IStreetService service)
        {
            return service.Add(TownId, StreetName, StreetTypeId);
        }
    }
}
