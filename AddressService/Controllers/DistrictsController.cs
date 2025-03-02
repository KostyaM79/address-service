using AddressService.Models;
using AddressService.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly IDistrictService service;

        public DistrictsController(IDistrictService service)
        {
            this.service = service;
        }

        [HttpPost]
        public int Create([FromBody] DistrictModel model)
        {
            return model.AddNewDistrict(service);
        }

        /// <summary>
        /// Возвращает массив районов конкретного региона.
        /// Пример вызова: <baseURL>/api/Districts/FindByRegionId?regionId=2
        /// </summary>
        /// <param name="regionId">Id региона</param>
        /// <returns>Массив районов: DistrictModel[]</returns>
        [HttpGet, Route(nameof(FindByRegionId))]
        public DistrictModel[] FindByRegionId(int regionId)
        {
            return service.FindByRegionId(regionId);
        }
    }
}
