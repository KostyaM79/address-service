using AddressService.Common;
using AddressService.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Models
{
    public class BuildingNumberModel : BuildingNumberModelBase
    {
        public int AddNewBuildingNumber(IBuildingNumberService service)
        {
            return service.Add(HouseNumberId, BuildingNumber);
        }
    }
}
