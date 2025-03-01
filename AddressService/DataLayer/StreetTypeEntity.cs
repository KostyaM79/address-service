using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    public class StreetTypeEntity
    {
        public int Id { get; set; }

        [Required, MaxLength(10)]
        public string StreetTypeName { get; set; }

        public ICollection<StreetEntity> Streets { get; set; }
    }
}
