using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScurityApp.ApiModel.RequestApiModel;
using ScurityApp.BLL.Services;
using ScurityApp.DAL.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScurityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryService countryService;
        private readonly IMapper mapper;
        public CountryController(CountryService countryService, IMapper mapper)
        {
            this.countryService = countryService;
            this.mapper = mapper;
        }

        // GET: api/<CountryController>
        [HttpGet]
        public async Task<List<Country>> Get()
        {
            return await this.countryService.GetAllCountriesAsync();
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CountryRequestApiModel countryRequestApi)
        {
            if (countryRequestApi == null)
            {
                return BadRequest();
            }

            var country = mapper.Map<Country>(countryRequestApi);
            await this.countryService.AddCountryAsync(country);
            return Ok();
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CountryRequestApiModel value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            var country = mapper.Map<Country>(value);
            country.Id = id;

            await this.countryService.UpdateCountryAsync(country);
            return Ok();
        }
            
        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.countryService.DeleteCountryByIdAsync(id);
            return Ok();
        }
    }
}
