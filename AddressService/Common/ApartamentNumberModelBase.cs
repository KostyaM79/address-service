using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Common
{
    public abstract class ApartamentNumberModelBase : ModelBase
    {
        [Required]
        public int BuildingNumberId { get; set; }

        [Required, MaxLength(5)]
        public string ApartamentNumber { get; set; }
    }
}
