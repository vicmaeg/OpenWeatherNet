using System;
using OpenWeatherNet.Interfaces;
using System.Net.Http;

namespace OpenWeatherNet
{
    public class WeatherClient : IWeatherClient
    {
        HttpClient httpClient;

        public WeatherClient (string appID) : this (new WeatherClientSettings(appID))
        {
        }

        public WeatherClient(WeatherClientSettings settings)
        {
            Settings = settings;
            httpClient = new HttpClient ();
        }

        public WeatherClientSettings Settings { get; }

        public virtual ICurrentWeatherClient Current =>
            new CurrentWeatherClient(httpClient, Settings);

        public virtual IForecastClient Forecast => throw new NotImplementedException();

        

    }
}
