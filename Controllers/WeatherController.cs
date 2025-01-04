using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherApp;

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

        var weather = await _weatherService.GetWeatherAsync(city);
        return View("WeatherResult", weather);
    }
}
