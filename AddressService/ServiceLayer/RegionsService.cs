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
    public class RegionsService : IRegionService
    {
        private readonly AppDbContext context;

        public RegionsService(AppDbContext context)
        {
            this.context = context;
        }

        public int Add(int countryId, string regionName, int regionStatusId)
        {
            SqlParameter param_countryId = new SqlParameter("@countryId", countryId);
            SqlParameter param_regionName = new SqlParameter("@regionName", regionName);
            SqlParameter param_regionStatusId = new SqlParameter("@regionStatusId", regionStatusId);
            SqlParameter outParam = new SqlParameter("@id", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Current, null);
            context.Database.ExecuteSqlRaw("AddRegionProc @countryId, @regionName, @regionStatusId, @id out", param_countryId, param_regionName, param_regionStatusId, outParam);
            return (int)outParam.Value;
        }

        /// <summary>
        /// Возвращает массив регионов конкретной страны.
        /// Пример вызова: <baseURL>/api/Regions/FindByCountryId?countryId=1
        /// </summary>
        /// <param name="countryId">Id страны</param>
        /// <returns>Массив регионов: RegionModel[]</returns>
        public RegionModel[] FindByCountryId(int countryId)
        {
            return context.Regions.AsNoTracking().Where(e => e.CountryId == countryId)
                .Select(e => new RegionModel()
                {
                    Id = e.Id,
                    CountryId = e.CountryId,
                    RegionName = e.RegionName,
                    RegionStatusId = e.RegionStatusId
                }).ToArray();
        }
    }
}
