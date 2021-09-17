using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class CityDto
    {
        [Required(ErrorMessage = "Id is required.")]
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
    }
}
