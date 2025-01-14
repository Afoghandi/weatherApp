namespace WeatherApp.Helpers
{
    public class WeatherIconMapper
    {
        // Maps weather descriotions to corresponding weather Icons classes

        public static string GetIconClass(string description)
        {
            return description.ToLower() switch
            {
                // Clear Weather
                "clear sky" => "wi wi-day-sunny",
                "few clouds" => "wi wi-day-cloudy",

                // Cloud Variants
                "scattered clouds" => "wi wi-cloud",
                "broken clouds" => "wi wi-cloudy",
                "overcast clouds" => "wi wi-cloudy",

                // Rain
                "light rain" => "wi wi-rain-mix",
                "moderate rain" => "wi wi-rain",
                "heavy rain" => "wi wi-showers",
                "shower rain" => "wi wi-showers",

                // Storms
                "thunderstorm" => "wi wi-thunderstorm",
                "storm showers" => "wi wi-storm-showers",
                "tornado" => "wi wi-tornado",

                // Snow
                "snow" => "wi wi-snow",
                "sleet" => "wi wi-sleet",
                "hail" => "wi wi-hail",

                // Fog and Mist
                "mist" => "wi wi-fog",
                "fog" => "wi wi-fog",
                "haze" => "wi wi-day-haze",
                "smoke" => "wi wi-smoke",
                "dust" => "wi wi-dust",
                "sandstorm" => "wi wi-sandstorm",

                // Wind
                "windy" => "wi wi-windy",
                "breeze" => "wi wi-cloudy-windy",

                // Temperature Extremes
                "hot" => "wi wi-hot",
                "cold" => "wi wi-snowflake-cold",

                // Miscellaneous
                "volcano" => "wi wi-volcano",
                "meteor" => "wi wi-meteor",
                "stars" => "wi wi-stars",

                // Default (unknown conditions)
                _ => "wi wi-na"

            };
        }
    }
}
