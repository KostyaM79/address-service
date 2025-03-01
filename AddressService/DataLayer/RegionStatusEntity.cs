using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    public class RegionStatusEntity
    {
        public int Id { get; set; }

        [Required, MaxLength(10)]
        public string RegionStatusName { get; set; }

        public ICollection<RegionEntity> Regions { get; set; }
    }
}
