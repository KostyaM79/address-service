using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using AddressService.DataLayer;

namespace AddressService.ServiceLayer
{
    public class CountriesService : ICountryService
    {
        private readonly AppDbContext context;

        public CountriesService(AppDbContext context)
        {
            this.context = context;
        }

        public int Add(string countryName)
        {
            SqlParameter param1 = new SqlParameter("@countryName", countryName);
            SqlParameter outParam = new SqlParameter("@id", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Current, null);
            context.Database.ExecuteSqlRaw("AddCountryProc @countryName, @id out", param1, outParam);
            return (int)outParam.Value;
        }
    }
}
