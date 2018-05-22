using System;
using OpenWeatherNet.Interfaces;
using System.Net.Http;

namespace OpenWeatherNet
{
	/// <summary>
	/// Weather client. Implements <see cref="IWeatherClient"/>, has different
	/// constructors depending on what level of control you want on the WeatherClient
	/// Then you can obtain the <see cref="ICurrentWeatherClient"/> and <see cref="IForecastClient"/>
	/// in order to do api calls.
	/// </summary>
	public class WeatherClient : IWeatherClient
	{
		HttpClient httpClient;

		readonly ICurrentWeatherClient currentWeatherClient;
		readonly IForecastClient forecastClient;

		public WeatherClient (string appID) : this (new WeatherClientSettings (appID))
		{
		}

		public WeatherClient (WeatherClientSettings settings) : this (settings, new HttpClient ())
		{
		}

		public WeatherClient (WeatherClientSettings settings, HttpClient client)
		{
			Settings = settings;
			httpClient = client;
			currentWeatherClient = new CurrentWeatherClient (httpClient, Settings);
			forecastClient = new ForecastClient (httpClient, Settings);
		}

		public WeatherClientSettings Settings { get; }

		public virtual ICurrentWeatherClient Current => currentWeatherClient;

		public virtual IForecastClient Forecast => forecastClient;
	}
}
