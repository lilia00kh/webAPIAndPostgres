using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DL.DomainModels;
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

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] WeatherAndCityDto weatherAndCityDto)
        {
            try
            {
                var weatherAndCityDomainModel = _autoMapper.Map<WeatherAndCityDomainModel>(weatherAndCityDto);
                await weatherAndCityService.UpdateWeatherAndCity(weatherAndCityDomainModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
