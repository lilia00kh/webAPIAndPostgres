using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DL.DomainModels
{
    public class WeatherAndCityDomainModel
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public Guid WeatherId { get; set; }
        [ForeignKey("CityId")]
        public CityDomainModel City { get; set; }
        
       
        [ForeignKey("WeatherId")]
        public WeatherDomainModel Weather { get; set; }

    }
}
