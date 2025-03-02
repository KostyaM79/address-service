using AddressService.Models;

namespace AddressService.ServiceLayer
{
    public interface IRegionService
    {
        int Add(int countryId, string regionName, int regionStatusId);

        RegionModel[] FindByCountryId(int countryId);
    }
}