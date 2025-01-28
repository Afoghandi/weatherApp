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
      
       private readonly string _apiKey;
      
        private const string WeatherEndpoint = "https://api.openweathermap.org/data/2.5/weather";
        private const string ForecastEndpoint = "https://api.openweathermap.org/data/2.5/forecast";


        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _apiKey = configuration["AppSettings:OpenWeatherApiKey"]?? throw new InvalidOperationException($"API Key not configured");
           
        }

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            
            var url = $"{WeatherEndpoint}?q={city}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetStringAsync(url);
            // Log the raw response
          
            return JsonConvert.DeserializeObject<WeatherData>(response);
        }

        public async Task<IEnumerable< ForecastItem>> GetForecastAsync(string city)
        {
            var url = $"{ForecastEndpoint}?q={city}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetStringAsync(url);

            var forecastData = JsonConvert.DeserializeObject<ForecastData>(response);
           
            var uniqueForecasts = forecastData.List
        .GroupBy(item => DateTimeOffset.FromUnixTimeSeconds(item.Dt).Date) // Group by parsed Date
        .Select(group =>
        {
            var firstItem = group.First();
            return new ForecastItem
            {
                Dt = firstItem.Dt,
                Date = group.Key, // Use the grouped date
                Main = new Main { Temp = group.Average(f => f.Main.Temp) },
                Condition = firstItem.Weather.First().Description,
                Icon = WeatherIconMapper.GetIconClass(firstItem.Weather.First().Description)
            };
        })
        .ToList();
          
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


        public async Task<WeatherAndForecastResult> GetWeatherAndForecastByLocationAsync(double latitude, double longitude)
        {

          
            var weatherUrl = $"{WeatherEndpoint}?lat={latitude}&lon={longitude}&appid={_apiKey}&units=metric";
            var forecastUrl = $"{ForecastEndpoint}?lat={latitude}&lon={longitude}&appid={_apiKey}&units=metric";

           
            var currentWatherResponse = await _httpClient.GetStringAsync(weatherUrl);
            var currentWeather = JsonConvert.DeserializeObject<WeatherData>(currentWatherResponse);

           
            var forecastResponse = await _httpClient.GetStringAsync(forecastUrl);
            var forecast = JsonConvert.DeserializeObject<ForecastData>(forecastResponse);

            var groupedForecast = forecast.List
                .GroupBy(f => DateTimeOffset.FromUnixTimeSeconds(f.Dt).Date)
                .Select(g => new 

                {
                    Date = g.Key,
                    
                    AvgTem = g.Average(f => f.Main.Temp),
                    Condition = g.First().Weather.First().Description,
                    Icon = WeatherIconMapper.GetIconClass(g.First().Weather.First().Description)
                } )
                .Select(a => new ForecastItem

                {
                    Date = a.Date,
                    Main = new Main { Temp = a.AvgTem},
                    Condition = a.Condition,
                    Icon = a.Icon,
                }
                ).ToList();

            return new WeatherAndForecastResult { CurrentWeather = currentWeather, Forecast = groupedForecast };
               

        }

    }


}
