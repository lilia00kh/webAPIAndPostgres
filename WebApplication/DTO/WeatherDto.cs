#nullable enable
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.DTO
{
    public class WeatherDto
    {
        [Required(ErrorMessage = "Id is required.")]
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "TemperatureC is required.")]

        public int? TemperatureC { get; set; }
        [Required(ErrorMessage = "Summary is required.")]

        public string? Summary { get; set; }
    }
}
