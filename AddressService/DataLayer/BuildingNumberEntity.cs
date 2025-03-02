using AddressService.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    [Index("HouseNumberId", "BuildingNumber", IsUnique = true, Name = "IX_BuildingNumbers")]
    public class BuildingNumberEntity : BuildingNumberModelBase
    {
        public HouseNumberEntity HouseNumber { get; set; }

        public ICollection<ApartamentNumberEntity> ApartamentNumbers { get; set; }
    }
}
