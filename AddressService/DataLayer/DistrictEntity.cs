using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    public class DistrictEntity
    {
        public int Id { get; set; }

        [Required]
        public int RegionId { get; set; }

        [Required, MaxLength(25)]
        public string DistrictName { get; set; }

        public RegionEntity Region { get; set; }

        public ICollection<TownStatusEntity> Towns { get; set; }
    }
}
