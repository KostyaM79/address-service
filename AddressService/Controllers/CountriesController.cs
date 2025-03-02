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
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService service;

        public CountriesController(ICountryService service)
        {
            this.service = service;
        }

        [HttpPost]
        public int Create([FromBody] CountryModel model)
        {
            return model.AddNewCountry(service);
        }
    }
}
