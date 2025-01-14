

namespace WeatherApp.Helpers
{
    public class WeatherBackgroundHelper 
    {
        public static  (string BackgroundClass, string SvgPath) GetBackgroundDetails(string condition)
        {
            return condition.ToLower() switch{

                // Clear Weather
                "clear sky" => ("bg-gradient-sunny", "/images/sunny.svg"),
                "few clouds" => ("bg-gradient-cloudy", "/images/cloudy.svg"),

                // Cloud Variants
                "scattered clouds" => ("bg-gradient-cloudy", "/images/cloudy.svg"),
                "broken clouds" => ("bg-gradient-cloudy", "/images/overcast.svg"),
                "overcast clouds" => ("bg-gradient-cloudy", "/images/overcast.svg"),

                // Rain
                "light rain" => ("bg-gradient-rainy", "/images/rainy.svg"),
                "moderate rain" => ("bg-gradient-rainy", "/images/rainy.svg"),
                "heavy rain" => ("bg-gradient-rainy", "/images/rainy.svg"),
                "shower rain" => ("bg-gradient-rainy", "/images/rainy.svg"),

                // Storms
                "thunderstorm" => ("bg-gradient-thunderstorm", "/images/thunderstorm.svg"),
                "storm showers" => ("bg-gradient-thunderstorm", "/images/thunderstorm.svg"),
                "tornado" => ("bg-gradient-thunderstorm", "/images/tornado.svg"),

                // Snow
                "snow" => ("bg-gradient-snowy", "/images/snowy.svg"),
                "sleet" => ("bg-gradient-snowy", "/images/sleet.svg"),
                "hail" => ("bg-gradient-snowy", "/images/hail.svg"),

                // Fog and Mist
                "mist" => ("bg-gradient-overcast", "/images/mist.svg"),
                "fog" => ("bg-gradient-overcast", "/images/fog.svg"),
                "haze" => ("bg-gradient-overcast", "/images/haze.svg"),
                "smoke" => ("bg-gradient-overcast", "/images/smoke.svg"),
                "dust" => ("bg-gradient-overcast", "/images/dust.svg"),
                "sandstorm" => ("bg-gradient-overcast", "/images/sandstorm.svg"),

                // Wind
                "windy" => ("bg-gradient-cloudy", "/images/windy.svg"),
                "breeze" => ("bg-gradient-cloudy", "/images/windy.svg"),

                // Temperature Extremes
                "hot" => ("bg-gradient-sunny", "/images/hot.svg"),
                "cold" => ("bg-gradient-snowy", "/images/cold.svg"),

                // Miscellaneous
                "volcano" => ("bg-gradient-overcast", "/images/volcano.svg"),
                "meteor" => ("bg-gradient-sunny", "/images/meteor.svg"),
                "stars" => ("bg-gradient-sunny", "/images/stars.svg"),

                // Default
                _ => ("bg-gradient-overcast", "/images/cloudy.svg")
            };
        }
    }
}
