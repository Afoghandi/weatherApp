using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using WeatherApp.Models.CurrentWeather;
using WeatherApp.Models.Forecast;

namespace WeatherApp
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "31469ed43f28e32aa411364b54ef2331";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";
        private const string WeatherEndpoint = "https://api.openweathermap.org/data/2.5/weather";
        private const string ForecastEndpoint = "https://api.openweathermap.org/data/2.5/forecast";


        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
           
        }

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            Console.WriteLine($"Fetching weather for: {city}");
            var url = $"{WeatherEndpoint}?q={city}&appid={ApiKey}&units=metric";
            var response = await _httpClient.GetStringAsync(url);
            // Log the raw response
          
            return JsonConvert.DeserializeObject<WeatherData>(response);
        }

        public async Task<ForecastData> GetForecastAsync(string city)
        {
            var url = $"{ForecastEndpoint}?q={city}&appid={ApiKey}&units=metric";
            var response = await _httpClient.GetStringAsync(url);
            // Log the raw response
           
            return JsonConvert.DeserializeObject<ForecastData>(response);
        }

    }


}
