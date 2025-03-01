using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.DataLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CountriyEntity> Countries { get; set; }

        public DbSet<RegionEntity> Regions { get; set; }

        public DbSet<RegionStatusEntity> RegionStatuses { get; set; }

        public DbSet<DistrictEntity> Districts { get; set; }

        public DbSet<TownEntity> Towns { get; set; }

        public DbSet<TownStatusEntity> TownStatuses { get; set; }

        public DbSet<StreetEntity> Streets { get; set; }

        public DbSet<StreetTypeEntity> StreetTypes { get; set; }

        public DbSet<HouseNumberEntity> HouseNumbers { get; set; }

        public DbSet<BuildingNumberEntity> BuildingNumbers { get; set; }

        public DbSet<ApartamentNumberEntity> ApartamentNumbers { get; set; }
    }
}
