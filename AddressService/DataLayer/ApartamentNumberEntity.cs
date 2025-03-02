using AddressService.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    [Index("BuildingNumberId", "ApartamentNumber", IsUnique = true, Name = "IX_ApartamentNumbers")]
    public class ApartamentNumberEntity : ApartamentNumberModelBase
    {
        public BuildingNumberEntity BuildingNumber { get; set; }
    }
}
