using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class WeatherAndCityDto
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public Guid WeatherId { get; set; }

    }
}
