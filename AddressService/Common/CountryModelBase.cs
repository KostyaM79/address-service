using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Common
{
    public abstract class CountryModelBase : ModelBase
    {
        [Required, MaxLength(25)]
        public string CountryName { get; set; }
    }
}
