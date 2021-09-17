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
    
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _autoMapper;

        public CityController(ICityService cityService, IMapper autoMapper)
        
        {
            _cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
            _autoMapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var citiesDto =  _autoMapper.Map<IEnumerable<CityDto>>(await _cityService.GetCities());
                return Ok(citiesDto);
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
                await _cityService.DeleteCityById(id);
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
                var city = _autoMapper.Map<CityDto>(await _cityService.GetCityById(id));
                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CityDto cityDto)
        {
            try
            {
                var cityDomainModel = _autoMapper.Map<CityDomainModel>(cityDto);
                await _cityService.UpdateCity(cityDomainModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CityDto cityDto)
        {
            try
            {
                var cityDomainModel = _autoMapper.Map<CityDomainModel>(cityDto);
                await _cityService.CreateCity(cityDomainModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
