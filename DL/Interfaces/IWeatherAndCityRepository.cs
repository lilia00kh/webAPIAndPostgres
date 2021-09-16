using DL.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL.Interfaces
{
    public interface IWeatherAndCityRepository: IRepositoryBase<WeatherAndCityDomainModel>
    {
        Task<IEnumerable<WeatherAndCityDomainModel>> GetAllWeathersAndCities();
        Task DeleteById(Guid id);
        Task<WeatherAndCityDomainModel> GetById(Guid id);
    }
}
