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
    public class HouseNumbersController : ControllerBase
    {
        private readonly IHouseNumberService service;

        public HouseNumbersController(IHouseNumberService service)
        {
            this.service = service;
        }

        [HttpPost]
        public int Create([FromBody] HouseNumberModel model)
        {
            return model.AddNewHouseNumber(service);
        }

        [HttpGet, Route(nameof(FindByStreetId))]
        public HouseNumberModel[] FindByStreetId(int streetId)
        {
            return service.FindByStreetId(streetId);
        }
    }
}
