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
    public class StreetsController : ControllerBase
    {
        private readonly IStreetService service;

        public StreetsController(IStreetService service)
        {
            this.service = service;
        }

        [HttpPost]
        public int Create([FromBody] StreetModel model)
        {
            return model.AddNewStreet(service);
        }
    }
}
