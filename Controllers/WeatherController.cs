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

    //public IActionResult FiveDayForecast()
    //{
    //    return View();
    //}

    [HttpPost]
 

    public async Task<IActionResult>GetWeatherAndForecast(string city)
    {
      
        if (string.IsNullOrWhiteSpace(city))
        {
            Console.WriteLine("City name is empty.");
            ViewBag.Error = "City name cannot be Empty";
            return View("Index");

        }
        try
        {
            var result = await _weatherService.GetWeatherAndForecastResultAsync(city);

            // Map the icon for current weather
            result.CurrentWeather.Weather[0].Icon = WeatherIconMapper.GetIconClass(result.CurrentWeather.Weather[0].Description);


            //Set dynamic background class
            var (backgroundClass, svgPath)= WeatherBackgroundHelper.GetBackgroundDetails(result.CurrentWeather.Weather[0].Description);
            ViewBag.BackgroundClass = backgroundClass;
            ViewBag.SvgPath = svgPath;  
            Console.WriteLine( $"Assigned BackgroundClass: {ViewBag.BackgroundClass}, Assigned svg: {svgPath}" );
            return View("WeatherAndForecastResult", result);
            // fetch curent weather
           
            //var weather = await _weatherService.GetWeatherAsync(city);

            //// Map the icon for the current weather condition
            //weather.Weather[0].Icon = WeatherIconMapper.GetIconClass(weather.Weather[0].Description);

            //// fetch 5-day forecast

            //var forecast = await _weatherService.GetForecastAsync(city);
           
            //var groupedForecast = forecast.List
            // .GroupBy(f => DateTimeOffset.FromUnixTimeSeconds(f.Dt).Date)
            // .Select(g => new
            // {
            //     Date = g.Key,
            //     AvgTemp = g.Average(f => f.Main.Temp),
            //     Condition = g.First().Weather.First().Description,
            //     Icon = WeatherIconMapper.GetIconClass(g.First().Weather.First().Description)
            // }
            // )
            // .ToList();

           
            //var bgClass = WeatherBackgroundHelper.GetBackgroundClass(weather.Weather[0].Description);
            //ViewBag.BackgroundClass = bgClass;
            //// Combine results into a single object

            //var results = new WeatherAndForecastResult
       
            //{


            //    CurrentWeather = weather,
            //    Forecast = groupedForecast,
            //};

           
            //return View("WeatherAndForecastResult", results);
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error fetching weather data: {ex.Message}");
            ViewBag.Error = "Unable to fetch weather data. Please try again.";
            return View("Index");
        }
          
    }
}
