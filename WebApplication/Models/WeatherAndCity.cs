using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class WeatherAndCity
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public Guid WeatherId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
        
       
        [ForeignKey("WeatherId")]
        public WeatherForecast Weather { get; set; }

    }
}
