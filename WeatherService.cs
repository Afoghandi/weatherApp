using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
namespace WeatherApp
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "31469ed43f28e32aa411364b54ef2331";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            var url = $"{BaseUrl}?q={city}&appid={ApiKey}&units=metric";
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<WeatherData>(response);
        }
    }

    public class WeatherData
    {
        public Main Main { get; set; }
        public string Name { get; set; }
        public Weather[] Weather { get; set; }
    }
    public class Main
    {
        public double Temp { get; set; }
        public double Feels_Like { get; set; }
    }
    public class Weather
    {
        public string Description { get; set; }
    }
}
