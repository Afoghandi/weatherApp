using System;
using System.Collections.Generic;
using WeatherApp.Models.CurrentWeather;

namespace WeatherApp.Models.Forecast
{
    public class ForecastItem
    {
        public long Dt { get; set; }

        public Main Main { get; set; }

        public List <Weather> Weather {  get; set; }    
    }
}
