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
        public bool ThrowOnError { get; set; }
        public int Retries { get; set; } = 0;
        public TimeSpan TimeBetweenRetries { get; set; } = TimeSpan.FromSeconds (0);
        public bool ExponentialBackoffInRetries { get; set; } = false;

    }
}
