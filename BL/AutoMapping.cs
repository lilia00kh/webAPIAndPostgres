using AutoMapper;
using BLL.Models;
using DL.DomainModels;

namespace BLL
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<WeatherDomainModel, WeatherModel>();
            CreateMap<CityDomainModel, CityModel>();
            CreateMap<WeatherAndCityDomainModel, WeatherAndCityModel>();
        }
    }
}
