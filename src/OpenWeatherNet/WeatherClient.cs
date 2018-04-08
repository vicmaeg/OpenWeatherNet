using System;
using OpenWeatherNet.Interfaces;
using System.Net.Http;

namespace OpenWeatherNet
{
    public class WeatherClient : IWeatherClient
    {
        HttpClient httpClient;

        ICurrentWeatherClient currentWeatherClient;
        IForecastClient forecastClient;

        public WeatherClient (string appID) : this (new WeatherClientSettings (appID))
        {
        }

        public WeatherClient (WeatherClientSettings settings)
        {
            Settings = settings;
            httpClient = new HttpClient ();
            currentWeatherClient = new CurrentWeatherClient (httpClient, Settings);
            forecastClient = new ForecastClient (httpClient, Settings);
        }

        public WeatherClientSettings Settings { get; }

        public virtual ICurrentWeatherClient Current => currentWeatherClient;

        public virtual IForecastClient Forecast => forecastClient;
    }
}
