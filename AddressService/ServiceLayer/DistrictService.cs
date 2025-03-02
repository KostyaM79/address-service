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
    public class DistrictService : IDistrictService
    {
        private readonly AppDbContext context;

        public DistrictService(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Вызывает хранимую процедуру для добавления нового района. Хранимая процедура проверяет, существует ли уже такой район в базе данных,
        /// и если нет, то добавляет новую запись в таблицу Districts и возвращает её Id, если же район уже имеется в базе данных, то процедура просто вернёт его Id.
        /// Таким образом, метод в любом случае возвращает Id района.
        /// </summary>
        /// <param name="regionId">Id региона</param>
        /// <param name="districtName">Название района</param>
        /// <returns></returns>
        public int Add(int regionId, string districtName)
        {
            SqlParameter param_regionId = new SqlParameter("@regionId", regionId);
            SqlParameter param_districtName = new SqlParameter("@districtName", districtName);
            SqlParameter outParam = new SqlParameter("@id", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Current, null);
            context.Database.ExecuteSqlRaw("AddDistrictProc @regionId, @districtName, @id out", param_regionId, param_districtName, outParam);
            return (int)outParam.Value;
        }

        /// <summary>
        /// Получает из базы данных районы и возвращает районы, связанные с регионом, Id которого перадано в метод.
        /// </summary>
        /// <param name="regionId">Id региона</param>
        /// <returns>Массив районов</returns>
        public DistrictModel[] FindByRegionId(int regionId)
        {
            return context.Districts.AsNoTracking().Where(e => e.RegionId == regionId)
                .Select(e => new DistrictModel()
                {
                    Id = e.Id,
                    RegionId = e.RegionId,
                    DistrictName = e.DistrictName
                }).ToArray();
        }
    }
}
