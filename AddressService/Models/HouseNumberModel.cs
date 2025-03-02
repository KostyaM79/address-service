using AddressService.Common;
using AddressService.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Models
{
    public class HouseNumberModel : HouseNumberModelBase
    {
        public int AddNewHouseNumber(IHouseNumberService service)
        {
            return service.Add(StreetId, HouseNumber);
        }
    }
}
