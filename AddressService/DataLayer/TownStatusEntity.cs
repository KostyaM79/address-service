using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    [Index("TownStatusName", IsUnique = true, Name = "IX_TownStatuses")]
    public class TownStatusEntity
    {
        public int Id { get; set; }

        [Required, MaxLength(10)]
        public string TownStatusName { get; set; }

        public ICollection<TownStatusEntity> Towns { get; set; }
    }
}
