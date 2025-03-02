using AddressService.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    [Index("RegionId", "DistrictName", IsUnique = true, Name = "IX_Districts")]
    public class DistrictEntity : DistrictModelBase
    {
        public RegionEntity Region { get; set; }

        public ICollection<TownStatusEntity> Towns { get; set; }
    }
}
