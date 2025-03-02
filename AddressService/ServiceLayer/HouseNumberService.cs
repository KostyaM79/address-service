using AddressService.DataLayer;
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
    }
}
