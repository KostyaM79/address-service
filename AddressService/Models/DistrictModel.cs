using AddressService.Common;
using AddressService.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Models
{
    public class DistrictModel : DistrictModelBase
    {
        public int AddNewDistrict(IDistrictService service)
        {
            return service.Add(RegionId, DistrictName);
        }
    }
}
