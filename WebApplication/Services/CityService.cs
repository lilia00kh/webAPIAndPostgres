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

        public async Task DeleteCityById(Guid id)
        {
            await _cityRepository.DeleteById(id);
        }

        public async Task<IEnumerable<CityDomainModel>> GetCities()
        {
            return await _cityRepository.GetAllCities();
        }

        public async Task<CityDomainModel> GetCityById(Guid id)
        {
            return await _cityRepository.GetById(id);
        }

        public Task UpdateCity(CityDto cityDto)
        {
            throw new NotImplementedException();
        }
    }
}
