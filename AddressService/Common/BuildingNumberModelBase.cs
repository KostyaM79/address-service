using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Common
{
    public abstract class BuildingNumberModelBase : ModelBase
    {
        [Required]
        public int HouseNumberId { get; set; }

        [Required, MaxLength(5)]
        public string BuildingNumber { get; set; }
    }
}
