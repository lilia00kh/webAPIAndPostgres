using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("weatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ApplicationContext _db = new ApplicationContext();
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var weatherForecasts = _db.WeatherForecasts.ToList();
            return weatherForecasts;
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<WeatherForecast> Delete(Guid id)
        {
            var weatherForecasts = _db.WeatherForecasts.ToList();
            var weather = weatherForecasts.FirstOrDefault(x => x.Id == id);
            if (weather != null) _db.WeatherForecasts.Remove(weather);
            _db.SaveChanges();
            return Ok(weather);
        }

        [HttpGet("get/{id}")]
        public ActionResult<WeatherForecast> Get(Guid id)
        {
            var weatherForecasts = _db.WeatherForecasts.ToList();
            var weather = weatherForecasts.FirstOrDefault(x => x.Id == id);
            if (weather == null)
                return NotFound();
            return new ObjectResult(weather);
        }

        [HttpPut("update")]
        public ActionResult<WeatherForecast> Update([FromBody] WeatherForecast weather)
        {
            var weatherForecasts = _db.WeatherForecasts.ToList();
            weather.Date = DateTime.Now;
            _db.WeatherForecasts.Update(weather);
            _db.SaveChanges();
            return Ok(weather);
        }

        [HttpPost("add")]
        public ActionResult<WeatherForecast> Add()
        {
            var rng = new Random();
            var weather1 = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).FirstOrDefault();

            var weather2 = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).FirstOrDefault();
            _db.WeatherForecasts.AddRange(weather1, weather2);
            _db.SaveChanges();
            return Ok();
        }
    }
}
