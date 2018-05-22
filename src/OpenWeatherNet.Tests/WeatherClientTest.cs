using System;
using NUnit.Framework;

namespace OpenWeatherNet.Tests
{
	[TestFixture]
	public class WeatherClientTest
	{
		string apiKey = "sfsdf-sdfsdf-sdfsdf-sdf";

		[Test]
		public void CreateWithOnlyApiKey_CreatedWithDefaultSettings ()
		{
			var weatherClient = new WeatherClient (apiKey);

			Assert.AreEqual (apiKey, weatherClient.Settings.AppId);
			Assert.AreEqual ("2.5", weatherClient.Settings.Version);
			Assert.AreEqual ("api.openweathermap.org/data", weatherClient.Settings.BaseURL);
			Assert.IsFalse (weatherClient.Settings.ThrowOnError);
			Assert.AreEqual (3, weatherClient.Settings.Retries);
			Assert.AreEqual (TimeSpan.FromSeconds (1), weatherClient.Settings.TimeBetweenRetries);
			Assert.IsFalse (weatherClient.Settings.ExponentialBackoffInRetries);
		}

		[Test]
		public void CreateWithCustomSettings ()
		{
			var settings = new WeatherClientSettings (apiKey)
			{
				Version = "4",
				BaseURL = "api.test.org/data",
				ThrowOnError = true,
				Retries = 5,
				TimeBetweenRetries = TimeSpan.FromSeconds (2),
				ExponentialBackoffInRetries = true
			};

			var weatherClient = new WeatherClient (settings);

			Assert.AreEqual (apiKey, weatherClient.Settings.AppId);
			Assert.AreEqual ("4", weatherClient.Settings.Version);
			Assert.AreEqual ("api.test.org/data", weatherClient.Settings.BaseURL);
			Assert.IsTrue (weatherClient.Settings.ThrowOnError);
			Assert.AreEqual (5, weatherClient.Settings.Retries);
			Assert.AreEqual (TimeSpan.FromSeconds (2), weatherClient.Settings.TimeBetweenRetries);
			Assert.IsTrue (weatherClient.Settings.ExponentialBackoffInRetries);
		}
	}
}
