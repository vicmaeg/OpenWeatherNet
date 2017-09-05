using OpenWeatherNet.Interfaces;

namespace OpenWeatherNet
{
    public class WeatherClient : IWeatherClient
    {
        public WeatherClientSettings Settings { get; set; }
    }
}
