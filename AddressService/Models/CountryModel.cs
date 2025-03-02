using AddressService.Common;
using AddressService.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Models
{
    public class CountryModel : CountryModelBase
    {
        public int AddNewCountry(ICountryService service)
        {
            return service.Add(CountryName);
        }
    }
}
