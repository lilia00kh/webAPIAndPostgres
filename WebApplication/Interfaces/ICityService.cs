using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL.DomainModels;
using WebApplication.DTO;

namespace WebApplication.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityDomainModel>> GetCities();
        Task DeleteCityById(Guid id);
        Task UpdateCity(CityDto cityDto);
        Task CreateCity(CityDto cityDto);
        Task<CityDto> GetCityById(Guid id);
    }
}
