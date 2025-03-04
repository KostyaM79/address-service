﻿using AddressService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.ServiceLayer
{
    public interface IDistrictService
    {
        int Add(int regionId, string districtName);

        DistrictModel[] FindByRegionId(int regionId);
    }
}
