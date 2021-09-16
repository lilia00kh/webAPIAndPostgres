using DL.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL.Interfaces
{
    public interface ICityRepository : IRepositoryBase<CityDomainModel>
    {
        public Task<IEnumerable<CityDomainModel>> GetAllCities();
        Task DeleteById(Guid id);
        Task<CityDomainModel> GetById(Guid id);
    }
}
