using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL.DomainModels;
using DL.Interfaces;
using WebApplication.DTO;
using WebApplication.Interfaces;

namespace WebApplication.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
        }
        public Task CreateCity(CityDto cityDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCityById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CityDomainModel>> GetCities()
        {
            return _cityRepository.GetAllCities();
        }

        public Task<CityDto> GetCityById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCity(CityDto cityDto)
        {
            throw new NotImplementedException();
        }
    }
}
