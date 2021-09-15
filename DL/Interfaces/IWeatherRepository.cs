﻿using DL.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DL.Interfaces
{
    public interface IWeatherRepository: IRepositoryBase<WeatherDomainModel>
    {
    }
}
