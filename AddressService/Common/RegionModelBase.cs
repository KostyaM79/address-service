using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Common
{
    public abstract class RegionModelBase : ModelBase
    {
        [Required]
        public int CountryId { get; set; }

        [Required, MaxLength(25)]
        public string RegionName { get; set; }

        [Required]
        public int RegionStatusId { get; set; }
    }
}
