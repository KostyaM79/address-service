using AddressService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.ServiceLayer
{
    public interface IApartamentNumberService
    {
        int Add(int buildingNumberId, string apartamentNumber);

        ApartamentNumberModel[] FindByBuildingNumberId(int buildingNumberId);
    }
}
