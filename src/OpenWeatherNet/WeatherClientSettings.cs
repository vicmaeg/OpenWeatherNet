using System;

namespace OpenWeatherNet
{
	/// <summary>
	/// Weather client settings. Pass an instance of this in WeatherClient in order to
	/// configure the weather client behaviours.
	/// </summary>
	public class WeatherClientSettings
	{
		public WeatherClientSettings (string appID)
		{
			AppId = appID;
		}

		/// <summary>
		/// Gets the app identifier. This is the ApiKey of OpenWeatherMap
		/// </summary>
		/// <value>The app identifier.</value>
		public string AppId { get; }

		/// <summary>
		/// Gets or sets the version of the OpenWeatherMap endpoints
		/// </summary>
		/// <value>The version.</value>
		public string Version { get; set; } = "2.5";

		/// <summary>
		/// Gets or sets the base URL of the OpenWeatherMap, change this if you
		/// have a proxy or a custom server that wrapps the ApiKey in a private server
		/// </summary>
		/// <value>The base URL.</value>
		public string BaseURL { get; set; } = "api.openweathermap.org/data";

		/// <summary>
		/// Gets or sets a value indicating whether the http client should throw on error.
		/// </summary>
		/// <value><c>true</c> if throw on error; otherwise, <c>false</c>.</value>
		public bool ThrowOnError { get; set; }

		/// <summary>
		/// Gets or sets the retries. When a api calls fails
		/// </summary>
		/// <value>The retries.</value>
		public int Retries { get; set; } = 3;

		/// <summary>
		/// Gets or sets the time between retries.
		/// </summary>
		/// <value>The time between retries.</value>
		public TimeSpan TimeBetweenRetries { get; set; } = TimeSpan.FromSeconds (1);

		/// <summary>
		/// Gets or sets a value indicating whether the http client has
		/// exponential backoff in retries.
		/// </summary>
		/// <value><c>true</c> if exponential backoff in retries; otherwise, <c>false</c>.</value>
		public bool ExponentialBackoffInRetries { get; set; } = false;

	}
}
