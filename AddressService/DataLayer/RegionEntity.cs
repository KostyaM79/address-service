using AddressService.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    [Index("CountryId", "RegionName", "RegionStatusId", IsUnique = true, Name = "IX_Regions")]
    public class RegionEntity : RegionModelBase
    {
        public CountriyEntity Country { get; set; }

        public RegionStatusEntity RegionStatus { get; set; }

        public ICollection<DistrictEntity> Districts { get; set; }
    }
}
