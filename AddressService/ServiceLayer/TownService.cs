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
    public class TownService : ITownService
    {
        private readonly AppDbContext context;

        public TownService(AppDbContext context)
        {
            this.context = context;
        }

        public int Add(int districtId, string townName, int townStatusId)
        {
            SqlParameter param_districtId = new SqlParameter("@districtId", districtId);
            SqlParameter param_townName = new SqlParameter("@townName", townName);
            SqlParameter param_townStatusId = new SqlParameter("@townStatusId", townStatusId);
            SqlParameter outParam = new SqlParameter("@id", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Current, null);
            context.Database.ExecuteSqlRaw("AddTownProc @districtId, @townName, @townStatusId, @id out", param_districtId, param_townName, param_townStatusId, outParam);
            return (int)outParam.Value;
        }

        public TownModel[] FindByDistrictId(int districtId)
        {
            return context.Towns.AsNoTracking().Where(e => e.DistrictId == districtId)
                .Select(e => new TownModel()
                {
                    Id = e.Id,
                    DistrictId = e.DistrictId,
                    TownName = e.TownName,
                    TownStatusId = e.TownStatusId
                }).ToArray();
        }
    }
}
