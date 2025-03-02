using AddressService.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    [Index("TownId", "StreetName", "StreetTypeId", IsUnique = true, Name = "IX_Streets")]
    public class StreetEntity : StreetModelBase
    {
        public TownEntity Town { get; set; }

        public StreetTypeEntity StreetType { get; set; }

        public ICollection<HouseNumberEntity> HouseNumbers { get; set; }
    }
}
