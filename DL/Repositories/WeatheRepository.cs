using DL.DomainModels;
using DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DL.Repositories
{
    public class WeatheRepository: RepositoryBase<WeatherDomainModel>, IWeatherRepository
    {
    }
}
