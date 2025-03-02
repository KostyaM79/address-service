using AddressService.Models;

namespace AddressService.ServiceLayer
{
    public interface ICountryService
    {
        int Add(string countryName);

        CountryModel[] GetAll();
    }
}