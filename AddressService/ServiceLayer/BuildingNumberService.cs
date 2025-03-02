using AddressService.DataLayer;
using AddressService.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.ServiceLayer
{
    public class BuildingNumberService : IBuildingNumberService
    {
        private readonly AppDbContext context;

        public BuildingNumberService(AppDbContext context)
        {
            this.context = context;
        }

        public int Add(int houseNumberId, string buildingNumber)
        {
            SqlParameter param_houseNumberId = new SqlParameter("@houseNumberId", houseNumberId);
            SqlParameter param_buildingNumber = new SqlParameter("@buildingNumber", buildingNumber);
            SqlParameter outParam = new SqlParameter("@id", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Current, null);
            context.Database.ExecuteSqlRaw("AddBuildingNumberProc @houseNumberId, @buildingNumber, @id out", param_houseNumberId, param_buildingNumber, outParam);
            return (int)outParam.Value;
        }

        public BuildingNumberModel[] FindByHouseNumberId(int houseNumberId)
        {
            return context.BuildingNumbers.AsNoTracking().Where(e => e.HouseNumberId == houseNumberId)
                .Select(e => new BuildingNumberModel()
                {
                    Id = e.Id,
                    HouseNumberId = e.HouseNumberId,
                    BuildingNumber = e.BuildingNumber
                }).ToArray();
        }
    }
}
