using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    [Index("StreetId", "HouseNumber", IsUnique = true, Name = "IX_HouseNumbers")]
    public class HouseNumberEntity
    {
        public int Id { get; set; }

        [Required]
        public int StreetId { get; set; }

        [Required, MaxLength(5)]
        public string HouseNumber { get; set; }

        public StreetEntity Street { get; set; }

        public ICollection<BuildingNumberEntity> BuildingNumbers { get; set; }
    }
}
