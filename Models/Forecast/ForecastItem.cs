using System;
using System.Collections.Generic;
using WeatherApp.Models.CurrentWeather;

namespace WeatherApp.Models.Forecast
{
    public class ForecastItem
    {
        public long Dt { get; set; }

        public Main Main { get; set; }

        public List<Weather> Weather { get; set; }



        public string Condition { get; set; }
        public string Icon {get; set;}
        public DateTime Date { get; set; }

    }
}
