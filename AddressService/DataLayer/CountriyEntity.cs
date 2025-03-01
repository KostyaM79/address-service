﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    public class CountriyEntity
    {
        public int Id { get; set; }

        [Required, MaxLength(25)]
        public string CountryName { get; set; }

        public ICollection<RegionEntity> Regions { get; set; }
    }
}
