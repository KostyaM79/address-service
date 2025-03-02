using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Common
{
    public abstract class StreetModelBase : ModelBase
    {
        [Required]
        public int TownId { get; set; }

        [Required, MaxLength(25)]
        public string StreetName { get; set; }

        [Required]
        public int StreetTypeId { get; set; }
    }
}
