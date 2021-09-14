using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.DTO;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherAndCityController : ControllerBase
    {
        private readonly ApplicationContext _db = new ApplicationContext();
        [HttpGet]
        public IEnumerable<WeatherAndCityDTO> Get()
        {
            var weathersAndCities = _db.WeathersAndCities.ToList();
            return weathersAndCities;
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<WeatherAndCityDTO> Delete(Guid id)
        {
            var weathersAndCities = _db.WeathersAndCities.ToList();
            var weatherAndCity = weathersAndCities.FirstOrDefault(x => x.Id == id);
            if (weatherAndCity != null) _db.WeathersAndCities.Remove(weatherAndCity);
            _db.SaveChanges();
            return Ok(weatherAndCity);
        }

        //something....

        [HttpGet("get/{id}")]
        public ActionResult<WeatherAndCityDTO> Get(Guid id)
        {
            var weathersAndCities = _db.WeathersAndCities.ToList();
            var weatherAndCity = weathersAndCities.FirstOrDefault(x => x.Id == id);
            if (weatherAndCity == null)
                return NotFound();
            return new ObjectResult(weatherAndCity);
        }

        [HttpPut("update")]
        public ActionResult<WeatherAndCityDTO> Update([FromBody] WeatherAndCityDTO weatherAndCity)
        {
            _db.WeathersAndCities.Update(weatherAndCity);
            _db.SaveChanges();
            return Ok(weatherAndCity);
        }

        [HttpPost("add")]
        public ActionResult<WeatherAndCityDTO> Add([FromBody] WeatherAndCityDTO weatherAndCity)
        {
            _db.WeathersAndCities.Add(weatherAndCity);
            _db.SaveChanges();
            return Ok();
        }
    }
}
