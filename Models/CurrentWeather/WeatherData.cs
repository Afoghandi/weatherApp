namespace WeatherApp.Models.CurrentWeather
{
    public class WeatherData
    {
        public Main Main {  get; set; } 
        public string Name { get; set; }
        public Weather[] Weather { get; set; }
    }


}
