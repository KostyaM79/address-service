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
    public class ApartamentNumbersController : ControllerBase
    {
        private readonly IApartamentNumberService service;

        public ApartamentNumbersController(IApartamentNumberService service)
        {
            this.service = service;
        }

        [HttpPost]
        public int Create([FromBody] ApartamentNumberModel model)
        {
            return model.AddNewApartamentNumber(service);
        }

        [HttpGet, Route(nameof(FindByBuildingNumberId))]
        public ApartamentNumberModel[] FindByBuildingNumberId(int buildingNumberId)
        {
            return service.FindByBuildingNumberId(buildingNumberId);
        }
    }
}
