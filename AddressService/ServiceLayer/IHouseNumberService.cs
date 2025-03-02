using AddressService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.ServiceLayer
{
    public interface IHouseNumberService
    {
        int Add(int streetId, string houseNumber);

        HouseNumberModel[] FindByStreetId(int streetId);
    }
}
