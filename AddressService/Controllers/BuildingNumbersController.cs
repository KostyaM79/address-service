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
    public class BuildingNumbersController : ControllerBase
    {
        private readonly IBuildingNumberService service;

        public BuildingNumbersController(IBuildingNumberService service)
        {
            this.service = service;
        }

        [HttpPost]
        public int Create([FromBody] BuildingNumberModel model)
        {
            return model.AddNewBuildingNumber(service);
        }
    }
}
