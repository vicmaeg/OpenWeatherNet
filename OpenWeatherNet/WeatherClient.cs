using System;
using OpenWeatherNet.Interfaces;

namespace OpenWeatherNet
{
    public class WeatherClient : IWeatherClient
    {
        public WeatherClientSettings Settings { get; set; }

        public ICurrentWeatherClient Current => throw new NotImplementedException();

        public IForecastClient Forecast => throw new NotImplementedException();
    }
}
