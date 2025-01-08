namespace WeatherApp.Helpers
{
    public class WeatherIconMapper
    {
        // Maps weather descriotions to corresponding weather Icons classes

        public static string GetIconClass(string description)
        {
            return description.ToLower() switch
            {
                "clear sky" => "wi wi-day-sunny",
                "few clouds"=> "wi wi-day-cloudy",
                "broken clouds"=> "wi wi-cloud",
                "scattered clouds" => "wi wi-cloud",
                "shower rain" => "wi wi-showers",
                "rain"=> "wi wi-rain",
                "thunderstorm"=> "wi wi-thunderstorm",
                "snow"=>"wi wi-snow",
                "mist"=>"wi wi-fog",
                _ =>"wi wi-na",// Default icon for unrecognised description



            };
        }
    }
}
