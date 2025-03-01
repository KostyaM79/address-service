using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    public class StreetEntity
    {
        public int Id { get; set; }

        [Required]
        public int TownId { get; set; }

        [Required, MaxLength(25)]
        public string StreetName { get; set; }

        [Required]
        public int StreetTypeId { get; set; }

        public TownEntity Town { get; set; }

        public StreetTypeEntity StreetType { get; set; }

        public ICollection<HouseNumberEntity> HouseNumbers { get; set; }
    }
}
