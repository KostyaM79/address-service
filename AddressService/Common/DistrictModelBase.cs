using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Common
{
    public abstract class DistrictModelBase : ModelBase
    {
        [Required]
        public int RegionId { get; set; }

        [Required, MaxLength(25)]
        public string DistrictName { get; set; }
    }
}
