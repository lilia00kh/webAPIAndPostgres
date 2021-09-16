using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //private readonly ApplicationContext _db = new ApplicationContext();
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
                var city = await _cityService.GetCityById(id);
                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPut("update")]
        //public async Task<IActionResult> Update([FromBody] CityDto cityDto)
        //{
        //    try
        //    {
        //        var cityModel = new CityDomainModel()
        //        {
        //            Id = cityDto.Id,
        //            Name = cityDto.Name
        //        };
        //        await _cityService.UpdateCity(cityModel);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPost("add")]
        //public async Task<IActionResult> Add([FromBody] CityDto cityDTO)
        //{
        //    try
        //    {
        //        var expJob = _autoMapper.Map<ExportJob>(exportJob.Data);
        //        var cityModel = new CityModel()
        //        {
        //            Id = cityDTO.Id,
        //            Name = cityDTO.Name
        //        };
        //        await _cityService.CreateCity(cityModel);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
