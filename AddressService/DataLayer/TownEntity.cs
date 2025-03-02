using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    [Index("DistrictId", "TownName", "TownStatusId", IsUnique = true, Name = "IX_Towns")]
    public class TownEntity
    {
        public int Id { get; set; }

        [Required]
        public int DistrictId { get; set; }

        [Required, MaxLength(25)]
        public string TownName { get; set; }

        [Required]
        public int TownStatusId { get; set; }

        public DistrictEntity District { get; set; }

        public TownStatusEntity TownStatus { get; set; }

        public ICollection<StreetEntity> Streets { get; set; }
    }
}
