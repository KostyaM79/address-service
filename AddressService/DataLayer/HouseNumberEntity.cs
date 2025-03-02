using AddressService.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    [Index("StreetId", "HouseNumber", IsUnique = true, Name = "IX_HouseNumbers")]
    public class HouseNumberEntity : HouseNumberModelBase
    {
        public StreetEntity Street { get; set; }

        public ICollection<BuildingNumberEntity> BuildingNumbers { get; set; }
    }
}
