using DL.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL.Interfaces
{
    public interface IWeatherAndCityRepository: IRepositoryBase<WeatherAndCityDomainModel>
    {
        public Task<IEnumerable<WeatherAndCityDomainModel>> GetAllWeathersAndCities();
    }
}
