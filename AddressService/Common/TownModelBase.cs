using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Common
{
    public abstract class TownModelBase : ModelBase
    {
        [Required]
        public int DistrictId { get; set; }

        [Required, MaxLength(25)]
        public string TownName { get; set; }

        [Required]
        public int TownStatusId { get; set; }
    }
}
