using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WeatherApp;
using WeatherApp.Helpers;
using WeatherApp.Models;
using WeatherApp.Models.CurrentWeather;
using WeatherApp.Models.Forecast;
public class WeatherController : Controller
{
    private readonly WeatherService _weatherService;

 

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
       
    }

    public IActionResult Index()
    {
        return View();
    }

  

    [HttpPost]

    [HttpGet]
    public async Task<IActionResult>GetWeatherAndForecast(string city, double? latitude, double? longitude)
    {
       

        try
        {
            if (!string.IsNullOrWhiteSpace(city))
            {
              
                var result = await _weatherService.GetWeatherAndForecastResultAsync(city);
                //Set dynamic BG and SVG
                var (backgroundClass, svgPath) = WeatherBackgroundHelper.GetBackgroundDetails(result.CurrentWeather.Weather[0].Description);
                ViewBag.BackgroundClass = backgroundClass;
                ViewBag.SvgPath = svgPath;
                return View("WeatherAndForecastResult", result);

            }
            else if (latitude.HasValue && longitude.HasValue){
               
                var result = await _weatherService.GetWeatherAndForecastByLocationAsync(latitude.Value, longitude.Value);

                //Set dynamic BG and SVG
                var (backgroundClass, svgPath) = WeatherBackgroundHelper.GetBackgroundDetails(result.CurrentWeather.Weather[0].Description);
                ViewBag.BackgroundClass = backgroundClass;
                ViewBag.SvgPath = svgPath;
                return View("WeatherAndForecastResult", result);

            }
            else
            {
                Console.WriteLine("City name is empty and location is not provided.");
                ViewBag.Error = "City name cannot be empty, and location services must be enabled.";
                return View("Index");

            }
           
        
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error fetching weather data: {ex.Message}");
            ViewBag.Error = "Unable to fetch weather data. Please try again.";
            return View("Index");
        }
          
    }

 
    
}
