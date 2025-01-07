using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherApp;
using WeatherApp.Helpers;

public class WeatherController : Controller
{
    private readonly WeatherService _weatherService;

 

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetWeather(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
           {
            ViewBag.Error = "City name cannot be empty.";
            return View("Index"); }
        // Fetch weather data from the service
        var weather = await _weatherService.GetWeatherAsync(city);

        //Map the weather description to the appropriate icon class
        if (weather.Weather != null && weather.Weather.Length> 0) {
            Console.WriteLine($"Weather Description: {weather.Weather[0].Description}");
            Console.WriteLine($"Mapped Icon Class: {weather.Weather[0].Icon}");
            weather.Weather[0].Icon = WeatherIconMapper.GetIconClass(weather.Weather[0].Description);
        }
      
        return View("WeatherResult", weather);
    }
}
