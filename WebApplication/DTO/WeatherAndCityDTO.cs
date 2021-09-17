using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class WeatherAndCityDto
    {
        [Required(ErrorMessage = "Id is required.")]
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "CityId is required.")]
        public Guid? CityId { get; set; }
        [Required(ErrorMessage = "WeatherId is required.")]
        public Guid? WeatherId { get; set; }

    }
}
