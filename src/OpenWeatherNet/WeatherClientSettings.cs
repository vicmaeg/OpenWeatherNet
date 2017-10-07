using System;

namespace OpenWeatherNet
{
    public class WeatherClientSettings
    {
        public WeatherClientSettings (string appID)
        {
            AppId = appID;
        }
        public string AppId { get; }
        public string Version { get; set; } = "2.5";
        public string BaseURL { get; set; } = "api.openweathermap.org/data";
    }
}
