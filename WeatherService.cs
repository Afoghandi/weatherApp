using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using WeatherApp.Helpers;
using WeatherApp.Models;
using WeatherApp.Models.CurrentWeather;
using WeatherApp.Models.Forecast;


namespace WeatherApp
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "31469ed43f28e32aa411364b54ef2331";
      
        private const string WeatherEndpoint = "https://api.openweathermap.org/data/2.5/weather";
        private const string ForecastEndpoint = "https://api.openweathermap.org/data/2.5/forecast";


        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
           
        }

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            
            var url = $"{WeatherEndpoint}?q={city}&appid={ApiKey}&units=metric";
            var response = await _httpClient.GetStringAsync(url);
            // Log the raw response
          
            return JsonConvert.DeserializeObject<WeatherData>(response);
        }

        public async Task<IEnumerable< ForecastItem>> GetForecastAsync(string city)
        {
            var url = $"{ForecastEndpoint}?q={city}&appid={ApiKey}&units=metric";
            var response = await _httpClient.GetStringAsync(url);

            var forecastData = JsonConvert.DeserializeObject<ForecastData>(response);

            var uniqueForecasts = forecastData.List
                .GroupBy(item => item.Date.Date)
                .Select(group =>
                {
                    var item = group.First();
                    item.Icon = WeatherIconMapper.GetIconClass(item.Condition);
                    return item;
                  }

                );
            return uniqueForecasts;

          

        }

        public async Task<WeatherAndForecastResult> GetWeatherAndForecastResultAsync(string city)
        {
            var currentWeather = await GetWeatherAsync(city);
            var forecast = await GetForecastAsync(city);
            return new WeatherAndForecastResult
            {
                CurrentWeather = currentWeather,
                Forecast = forecast
             
         
            };
        }

    }


}
