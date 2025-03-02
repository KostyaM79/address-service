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
    public class RegionsController : ControllerBase
    {
        private readonly IRegionService service;

        public RegionsController(IRegionService service)
        {
            this.service = service;
        }

        [HttpPost]
        public int Create([FromBody] RegionModel model)
        {
            return model.AddNewRegion(service);
        }
    }
}
