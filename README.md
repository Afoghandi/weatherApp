namespace WeatherApp
{
    public class README
    {

    # Weather App

This project is a dynamic weather forecasting application built using ASP.NET Core MVC. It integrates with the OpenWeatherMap API to fetch current weather data and a 5-day forecast, and it dynamically adjusts the UI based on location and weather conditions.

## Features

### Core Functionalities
1. **Current Weather**: Displays temperature, condition, and a dynamic icon.
2. **5-Day Forecast**: Provides daily average temperatures, conditions, and icons.
3. **Location-Based Search**:
   - Allows users to fetch weather data for their current location.
   - Users can manually search by entering a city name.
4. **Dynamic Backgrounds**: Background colors and animations change based on weather conditions.
5. **Responsive UI**: TailwindCSS ensures a seamless experience across devices.

### Tech Stack
- **Backend**: ASP.NET Core MVC
- **Frontend**: TailwindCSS, Weather Icons, SVG animations
- **API Integration**: OpenWeatherMap API

## Folder Structure

```
.
├── Controllers
│   ├── WeatherController.cs
├── Helpers
│   ├── WeatherBackgroundHelper.cs
│   ├── WeatherIconMapper.cs
├── Models
│   ├── CurrentWeather
│   │   ├── Main.cs
│   │   ├── Weather.cs
│   │   ├── WeatherData.cs
│   ├── Forecast
│   │   ├── ForecastData.cs
│   │   ├── ForecastItem.cs
│   ├── WeatherAndForecastResult.cs
├── Views
│   ├── Shared
│   │   ├── _Layout.cshtml
│   ├── Weather
│       ├── Index.cshtml
│       ├── WeatherAndForecastResult.cshtml
├── wwwroot
│   ├── css
│   │   ├── site.css
│   ├── images
│   │   ├── sunny.svg
│   │   ├── cloudy.svg
│   │   ├── rainy.svg
│   │   ├── snowy.svg
│   │   ├── overcast.svg
│   │   ├── ... (other weather icons)
├── Program.cs
├── WeatherService.cs
├── tailwind.config.js
```

## Setup Instructions

### Prerequisites
- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (for TailwindCSS)

### Steps
1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd weather-app
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Set up TailwindCSS:
   ```bash
   npm install
   ```

4. Build TailwindCSS:
   ```bash
   npx tailwindcss -i ./wwwroot/css/site.css -o ./wwwroot/css/output.css --watch
   ```

5. Run the application:
   ```bash
   dotnet run
   ```

6. Access the application:
   Navigate to `http://localhost:5000` in your web browser.

## API Integration

### OpenWeatherMap API
- Sign up for a free API key at [OpenWeatherMap](https://openweathermap.org/api).
- Add the API key to `WeatherService.cs`:
  ```csharp
  private const string ApiKey = "<your-api-key>";
  ```

## Contribution Guidelines
1. Fork the repository.
2. Create a feature branch.
3. Submit a pull request with detailed explanations of changes.


    }
}
