using System.Collections.Generic;
using WeatherApp.Models.CurrentWeather;
using WeatherApp.Models.Forecast;
namespace WeatherApp.Models
{
    public class WeatherAndForecastResult
    {

        public WeatherData CurrentWeather { get; set; }
        public IEnumerable <ForecastItem> Forecast {  get; set; }    
    }
}
