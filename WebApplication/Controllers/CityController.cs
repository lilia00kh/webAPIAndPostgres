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
    public class CityController : ControllerBase
    {
        private readonly ApplicationContext _db = new ApplicationContext();
        [HttpGet]
        public IEnumerable<WeatherForecastDTO> Get()
        {
            var weatherForecasts = _db.WeatherForecasts.ToList();
            return weatherForecasts;
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<CityDTO> Delete(Guid id)
        {
            var cities = _db.Cities.ToList();
            var city = cities.FirstOrDefault(x => x.Id == id);
            if (city != null) _db.Cities.Remove(city);
            _db.SaveChanges();
            return Ok(city);
        }

        [HttpGet("get/{id}")]
        public ActionResult<CityDTO> Get(Guid id)
        {
            var cities = _db.Cities.ToList();
            var city = cities.FirstOrDefault(x => x.Id == id);
            if (city == null)
                return NotFound();
            return new ObjectResult(city);
        }

        [HttpPut("update")]
        public ActionResult<CityDTO> Update([FromBody] CityDTO city)
        {
            _db.Cities.Update(city);
            _db.SaveChanges();
            return Ok(city);
        }

        [HttpPost("add")]
        public ActionResult<CityDTO> Add([FromBody] CityDTO city)
        {
            _db.Cities.Add(city);
            _db.SaveChanges();
            return Ok();
        }
    }
}
