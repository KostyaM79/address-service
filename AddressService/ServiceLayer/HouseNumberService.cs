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
    public class HouseNumberService : IHouseNumberService
    {
        private readonly AppDbContext context;

        public HouseNumberService(AppDbContext context)
        {
            this.context = context;
        }

        public int Add(int streetId, string houseNumber)
        {
            SqlParameter param_streetId = new SqlParameter("@streetId", streetId);
            SqlParameter param_houseNumber = new SqlParameter("@houseNumber", houseNumber);
            SqlParameter outParam = new SqlParameter("@id", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Current, null);
            context.Database.ExecuteSqlRaw("AddHouseNumberProc @streetId, @houseNumber, @id out", param_streetId, param_houseNumber, outParam);
            return (int)outParam.Value;
        }

        public HouseNumberModel[] FindByStreetId(int streetId)
        {
            return context.HouseNumbers.AsNoTracking().Where(e => e.StreetId == streetId)
                .Select(e => new HouseNumberModel()
                {
                    Id = e.Id,
                    StreetId = e.StreetId,
                    HouseNumber = e.HouseNumber
                }).ToArray();
        }
    }
}
