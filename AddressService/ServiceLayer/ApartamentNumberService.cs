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
    public class ApartamentNumberService : IApartamentNumberService
    {
        private readonly AppDbContext context;

        public ApartamentNumberService(AppDbContext context)
        {
            this.context = context;
        }

        public int Add(int buildingNumberId, string apartamentNumber)
        {
            SqlParameter param_buildingNumberId = new SqlParameter("@buildingNumberId", buildingNumberId);
            SqlParameter param_apartamentNumber = new SqlParameter("@apartamentNumber", apartamentNumber);
            SqlParameter outParam = new SqlParameter("@id", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Current, null);
            context.Database.ExecuteSqlRaw("AddApartamentNumberProc @buildingNumberId, @apartamentNumber, @id out", param_buildingNumberId, param_apartamentNumber, outParam);
            return (int)outParam.Value;
        }
    }
}
