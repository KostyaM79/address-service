using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    [Index("HouseNumberId", IsUnique = true, Name = "IX_BuildingNumbers")]
    public class BuildingNumberEntity
    {
        public int Id { get; set; }

        [Required]
        public int HouseNumberId { get; set; }

        [Required, MaxLength(5)]
        public string BuildingNumber { get; set; }

        public HouseNumberEntity HouseNumber { get; set; }

        public ICollection<ApartamentNumberEntity> ApartamentNumbers { get; set; }
    }
}
