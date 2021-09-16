using DL.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL.Interfaces
{
    public interface IWeatherRepository: IRepositoryBase<WeatherDomainModel>
    {
        Task<IEnumerable<WeatherDomainModel>> GetAllWeathers();
        Task DeleteById(Guid id);
    }
}
