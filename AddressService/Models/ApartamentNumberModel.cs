using AddressService.Common;
using AddressService.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Models
{
    public class ApartamentNumberModel : ApartamentNumberModelBase
    {
        public int AddNewApartamentNumber(IApartamentNumberService service)
        {
            return service.Add(BuildingNumberId, ApartamentNumber);
        }
    }
}
