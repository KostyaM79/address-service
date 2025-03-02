using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Common
{
    public abstract class HouseNumberModelBase : ModelBase
    {
        [Required]
        public int StreetId { get; set; }

        [Required, MaxLength(5)]
        public string HouseNumber { get; set; }
    }
}
