using AutoMapper;
using DL.DomainModels;
using WebApplication.DTO;

namespace BLL
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<WeatherDomainModel, WeatherDto>();
            CreateMap<CityDomainModel, CityDto>();
            CreateMap<WeatherAndCityDomainModel, WeatherAndCityDto>();
            CreateMap<WeatherDto, WeatherDomainModel>();
            CreateMap<CityDto, CityDomainModel>();
            CreateMap<WeatherAndCityDto, WeatherAndCityDomainModel>();
        }
    }
}
