using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityController : ControllerBase
    {
        private readonly ApplicationContext _db = new ApplicationContext();
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var weatherForecasts = _db.WeatherForecasts.ToList();
            return weatherForecasts;
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<City> Delete(Guid id)
        {
            var cities = _db.Cities.ToList();
            var city = cities.FirstOrDefault(x => x.Id == id);
            if (city != null) _db.Cities.Remove(city);
            _db.SaveChanges();
            return Ok(city);
        }

        [HttpGet("get/{id}")]
        public ActionResult<City> Get(Guid id)
        {
            var cities = _db.Cities.ToList();
            var city = cities.FirstOrDefault(x => x.Id == id);
            if (city == null)
                return NotFound();
            return new ObjectResult(city);
        }

        [HttpPut("update")]
        public ActionResult<City> Update([FromBody] City city)
        {
            _db.Cities.Update(city);
            _db.SaveChanges();
            return Ok(city);
        }

        [HttpPost("add")]
        public ActionResult<City> Add([FromBody] City city)
        {
            _db.Cities.Add(city);
            _db.SaveChanges();
            return Ok();
        }
    }
}
