using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApplication.DTO;
using WebApplication.Interfaces;
using DL.DomainModels;

namespace WebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class WeatherController : ControllerBase
    {

        private readonly IWeatherService weatherService;
        private readonly IMapper _autoMapper;

        public WeatherController(IWeatherService weatherService, IMapper autoMapper)
        {
            this.weatherService = weatherService;
            _autoMapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var weathersDto = _autoMapper.Map< IEnumerable<WeatherDto>>(await weatherService.GetWeathers());
                return Ok(weathersDto);
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
                await weatherService.DeleteWeatherById(id);
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
                var weather = _autoMapper.Map<WeatherDto>(await weatherService.GetWeatherById(id));
                return Ok(weather);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] WeatherDto weatherDto)
        {
            try
            {
                var weatherDomainModel = _autoMapper.Map<WeatherDomainModel>(weatherDto);
                await weatherService.UpdateWeather(weatherDomainModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] WeatherDto weatherDto)
        {
            try
            {
                var weatherDomainModel = _autoMapper.Map<WeatherDomainModel>(weatherDto);
                await weatherService.CreateWeather(weatherDomainModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
