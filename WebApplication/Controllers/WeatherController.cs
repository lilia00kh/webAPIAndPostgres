using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.DTO;
using WebApplication.Interfaces;

namespace WebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class WeatherController : ControllerBase
    {
        //private readonly ApplicationContext _db = new ApplicationContext();
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        //[HttpGet]
        //public IEnumerable<WeatherDTO> Get()
        //{
        //    var weatherForecasts = new List<WeatherDTO>() /*_db.WeatherForecasts.ToList()*/;
        //    return weatherForecasts;
        //}

        //[HttpDelete("delete/{id}")]
        //public ActionResult<WeatherDTO> Delete(Guid id)
        //{
        //    //var weatherForecasts = _db.WeatherForecasts.ToList();
        //    //var weather = weatherForecasts.FirstOrDefault(x => x.Id == id);
        //    //if (weather != null) _db.WeatherForecasts.Remove(weather);
        //    //_db.SaveChanges();
        //    return Ok();
        //}

        //[HttpGet("get/{id}")]
        //public ActionResult<WeatherDTO> Get(Guid id)
        //{
        //    //var weatherForecasts = _db.WeatherForecasts.ToList();
        //    //var weather = weatherForecasts.FirstOrDefault(x => x.Id == id);
        //    //if (weather == null)
        //    //    return NotFound();
        //    return Ok();
        //}

        //[HttpPut("update")]
        //public ActionResult<WeatherDTO> Update([FromBody] WeatherDTO weather)
        //{
        //    //var weatherForecasts = _db.WeatherForecasts.ToList();
        //    //weather.Date = DateTime.Now;
        //    //_db.WeatherForecasts.Update(weather);
        //    //_db.SaveChanges();
        //    return Ok(/*weather*/);
        //}

        //[HttpPost("add")]
        //public ActionResult<WeatherDTO> Add()
        //{
        //    //var rng = new Random();
        //    //var weather1 = Enumerable.Range(1, 5).Select(index => new WeatherForecastDTO
        //    //{
        //    //    Date = DateTime.Now.AddDays(index),
        //    //    TemperatureC = rng.Next(-20, 55),
        //    //    Summary = Summaries[rng.Next(Summaries.Length)]
        //    //}).FirstOrDefault();

        //    //var weather2 = Enumerable.Range(1, 5).Select(index => new WeatherForecastDTO
        //    //{
        //    //    Date = DateTime.Now.AddDays(index),
        //    //    TemperatureC = rng.Next(-20, 55),
        //    //    Summary = Summaries[rng.Next(Summaries.Length)]
        //    //}).FirstOrDefault();
        //    //_db.WeatherForecasts.AddRange(weather1, weather2);
        //    //_db.SaveChanges();
        //    return Ok();
        //}
    }
}
