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
    public class StreetService : IStreetService
    {
        private readonly AppDbContext context;

        public StreetService(AppDbContext context)
        {
            this.context = context;
        }

        public int Add(int townId, string streetName, int streetTypeId)
        {
            SqlParameter param_townId = new SqlParameter("@townId", townId);
            SqlParameter param_streetName = new SqlParameter("@streetName", streetName);
            SqlParameter param_streetTypeId = new SqlParameter("@streetTypeId", streetTypeId);
            SqlParameter outParam = new SqlParameter("@id", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Current, null);
            context.Database.ExecuteSqlRaw("AddStreetProc @townId, @streetName, @streetTypeId, @id out", param_townId, param_streetName, param_streetTypeId, outParam);
            return (int)outParam.Value;
        }
    }
}
