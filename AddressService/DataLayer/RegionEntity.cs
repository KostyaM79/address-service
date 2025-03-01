using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    public class RegionEntity
    {
        public int Id { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required, MaxLength(25)]
        public string RegionName { get; set; }

        [Required]
        public int RegionStatusId { get; set; }

        public CountriyEntity Country { get; set; }

        public RegionStatusEntity RegionStatus { get; set; }

        public ICollection<DistrictEntity> Districts { get; set; }
    }
}
