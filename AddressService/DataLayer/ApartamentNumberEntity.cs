using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    public class ApartamentNumberEntity
    {
        public int Id { get; set; }

        [Required]
        public int BuildingNumberId { get; set; }

        [Required, MaxLength(5)]
        public string ApartamentNumber { get; set; }

        public BuildingNumberEntity BuildingNumber { get; set; }
    }
}
