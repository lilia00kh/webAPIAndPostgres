using System;

namespace DL.DomainModels
{
    public class WeatherDomainModel
    {
        public Guid Id { get; set; }
        public DateTime Date => DateTime.Now;

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
