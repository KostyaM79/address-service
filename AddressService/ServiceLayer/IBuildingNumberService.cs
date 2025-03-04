﻿using AddressService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.ServiceLayer
{
    public interface IBuildingNumberService
    {
        int Add(int houseNumberId, string buildingNumber);

        BuildingNumberModel[] FindByHouseNumberId(int houseNumberId);
    }
}
