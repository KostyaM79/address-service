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
    public class TownsController : ControllerBase
    {
        private readonly ITownService service;

        public TownsController(ITownService service)
        {
            this.service = service;
        }

        [HttpPost]
        public int Create([FromBody] TownModel model)
        {
            return model.AddNewTown(service);
        }

        [HttpGet, Route(nameof(FindByDistrictId))]
        public TownModel[] FindByDistrictId(int districtId)
        {
            return service.FindByDistrictId(districtId);
        }
    }
}
