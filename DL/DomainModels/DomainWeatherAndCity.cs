using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DL.DomainModels
{
    public class DomainWeatherAndCity
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public Guid WeatherId { get; set; }
        [ForeignKey("CityId")]
        public DomainCity City { get; set; }
        
       
        [ForeignKey("WeatherId")]
        public WeatherForecast Weather { get; set; }

    }
}
