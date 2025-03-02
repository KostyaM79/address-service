using AddressService.Common;
using AddressService.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Models
{
    public class TownModel : TownModelBase
    {
        public int AddNewTown(ITownService service)
        {
            return service.Add(DistrictId, TownName, TownStatusId);
        }
    }
}
