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
    public class DistrictService : IDistrictService
    {
        private readonly AppDbContext context;

        public DistrictService(AppDbContext context)
        {
            this.context = context;
        }

        public int Add(int regionId, string districtName)
        {
            SqlParameter param_regionId = new SqlParameter("@regionId", regionId);
            SqlParameter param_districtName = new SqlParameter("@districtName", districtName);
            SqlParameter outParam = new SqlParameter("@id", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Current, null);
            context.Database.ExecuteSqlRaw("AddDistrictProc @regionId, @districtName, @id out", param_regionId, param_districtName, outParam);
            return (int)outParam.Value;
        }
    }
}
