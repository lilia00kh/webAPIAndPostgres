using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApplication.DTO;
using WebApplication.Interfaces;

namespace WebApplication.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class WeatherAndCityController : ControllerBase
    {
        private readonly IWeatherAndCityService weatherAndCityService;
        private readonly IMapper _autoMapper;

        public WeatherAndCityController(IWeatherAndCityService weatherAndCityService, IMapper autoMapper)
        {
            this.weatherAndCityService = weatherAndCityService;
            _autoMapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
        }
        ////private readonly ApplicationContext _db = new ApplicationContext();
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var weathersAndCitesDto = _autoMapper.Map< IEnumerable<WeatherAndCityDto>>(await weatherAndCityService.GetWeathersAndCities());
                return Ok(weathersAndCitesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await weatherAndCityService.DeleteWeatherAndCityById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var weatherAndCity = _autoMapper.Map<WeatherAndCityDto>(await weatherAndCityService.GetWeatherAndCityById(id));
                return Ok(weatherAndCity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        ////something....

        //[HttpGet("get/{id}")]
        //public ActionResult<WeatherAndCityDTO> Get(Guid id)
        //{
        //    var weathersAndCities = _db.WeathersAndCities.ToList();
        //    var weatherAndCity = weathersAndCities.FirstOrDefault(x => x.Id == id);
        //    if (weatherAndCity == null)
        //        return NotFound();
        //    return new ObjectResult(weatherAndCity);
        //}

        //[HttpPut("update")]
        //public ActionResult<WeatherAndCityDTO> Update([FromBody] WeatherAndCityDTO weatherAndCity)
        //{
        //    _db.WeathersAndCities.Update(weatherAndCity);
        //    _db.SaveChanges();
        //    return Ok(weatherAndCity);
        //}

        //[HttpPost("add")]
        //public ActionResult<WeatherAndCityDTO> Add([FromBody] WeatherAndCityDTO weatherAndCity)
        //{
        //    _db.WeathersAndCities.Add(weatherAndCity);
        //    _db.SaveChanges();
        //    return Ok();
        //}
    }
}
