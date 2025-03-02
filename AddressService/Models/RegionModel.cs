using AddressService.Common;
using AddressService.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Models
{
    public class RegionModel : RegionModelBase
    {
        public int AddNewRegion(IRegionService service)
        {
            return service.Add(CountryId, RegionName, RegionStatusId);
        }
    }
}
