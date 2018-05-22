using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenWeatherNet.Model;

namespace OpenWeatherNet.Tests
{
	[TestFixture]
	public class ClientBaseTest
	{
		//Use CurrentWeatherClient to test client base, since it is abstract
		CurrentWeatherClient client;

		public void SetUpWithSettings (WeatherClientSettings settings, Func<Task<HttpResponseMessage>> mockResponseMessage)
		{
			var httpclient = MockHttpClient.GetMockClient (mockResponseMessage);
			client = new CurrentWeatherClient (httpclient, settings);
		}


		[Test]
		public void ConfiguredWithThrowOnError_ResponseHasError_Throws ()
		{
			var settings = new WeatherClientSettings ("apiKey");
			settings.Retries = 0;
			settings.ThrowOnError = true;
			SetUpWithSettings (settings, () =>
			{
				var response = new HttpResponseMessage (System.Net.HttpStatusCode.NotFound);
				return Task.FromResult (response);
			});

			Assert.Throws<HttpRequestException> (async () => await client.GetByName ("Barcelona"));
		}

		[Test]
		public void NotConfiguredWithThrowOnError_ResponseHasError_ReturnsNull ()
		{
			var settings = new WeatherClientSettings ("apiKey");
			settings.Retries = 0;
			settings.ThrowOnError = false;
			SetUpWithSettings (settings, () =>
			{
				var response = new HttpResponseMessage (System.Net.HttpStatusCode.NotFound);
				return Task.FromResult (response);
			});


			CurrentWeather weather = new CurrentWeather ();
			Assert.DoesNotThrow (async () => weather = await client.GetByName ("Barcelona"));
			Assert.IsNull (weather);
		}

		[Test]
		public async Task ConfiguredWithSixRetries_ResponseHasError_SixTimesRetrying ()
		{
			var settings = new WeatherClientSettings ("apiKey");
			settings.Retries = 6;
			settings.ThrowOnError = false;
			settings.TimeBetweenRetries = TimeSpan.FromSeconds (0);
			int timesTried = 0;
			SetUpWithSettings (settings, () =>
			{
				timesTried++;
				var response = new HttpResponseMessage (System.Net.HttpStatusCode.InternalServerError);
				return Task.FromResult (response);
			});


			CurrentWeather weather = await client.GetByName ("Barcelona");
			Assert.IsNull (weather);
			//one of the actual request and 6 for the retries
			Assert.AreEqual (7, timesTried);
		}

		[Test]
		public async Task ConfiguredWithRetries_NotFoundError_NotRetrying ()
		{
			var settings = new WeatherClientSettings ("apiKey");
			settings.Retries = 6;
			settings.ThrowOnError = false;
			settings.TimeBetweenRetries = TimeSpan.FromSeconds (0);
			int timesTried = 0;
			SetUpWithSettings (settings, () =>
			{
				timesTried++;
				var response = new HttpResponseMessage (System.Net.HttpStatusCode.NotFound);
				return Task.FromResult (response);
			});


			CurrentWeather weather = await client.GetByName ("Barcelona");
			Assert.IsNull (weather);
			//one of the actual request
			Assert.AreEqual (1, timesTried);
		}

		[Test]
		public async Task ConfiguredWith_2SecondsTimeBetweenRetries_2Retries_TotalTimeExecuting_bigger_than_4_sec ()
		{
			var settings = new WeatherClientSettings ("apiKey");
			settings.Retries = 2;
			settings.ThrowOnError = false;
			settings.TimeBetweenRetries = TimeSpan.FromSeconds (2);
			int timesTried = 0;
			Stopwatch stopwatch = new Stopwatch ();

			SetUpWithSettings (settings, () =>

			{
				timesTried++;
				var response = new HttpResponseMessage (System.Net.HttpStatusCode.InternalServerError);
				return Task.FromResult (response);
			});

			stopwatch.Start ();
			CurrentWeather weather = await client.GetByName ("Barcelona");
			stopwatch.Stop ();

			Assert.IsNull (weather);
			//one of the actual request and 2 for the retries
			Assert.AreEqual (3, timesTried);
			Assert.GreaterOrEqual (stopwatch.Elapsed, TimeSpan.FromSeconds (4));
			Assert.Less (stopwatch.Elapsed, TimeSpan.FromSeconds (5));
		}

		[Test]
		public async Task ConfiguredWith_2SecondsTimeBetweenRetries_2_Retries_ExponentialBackoff ()
		{
			var settings = new WeatherClientSettings ("apiKey");
			settings.Retries = 2;
			settings.ThrowOnError = false;
			settings.TimeBetweenRetries = TimeSpan.FromSeconds (2);
			settings.ExponentialBackoffInRetries = true;
			int timesTried = 0;
			Stopwatch stopwatch = new Stopwatch ();

			SetUpWithSettings (settings, () =>

			{
				timesTried++;
				var response = new HttpResponseMessage (System.Net.HttpStatusCode.InternalServerError);
				return Task.FromResult (response);
			});

			stopwatch.Start ();
			CurrentWeather weather = await client.GetByName ("Barcelona");
			stopwatch.Stop ();

			Assert.IsNull (weather);
			//one of the actual request and 2 for the retries
			Assert.AreEqual (3, timesTried);
			Assert.GreaterOrEqual (stopwatch.Elapsed.Ticks, TimeSpan.FromSeconds (6).Ticks);
		}

		[Test]
		public async Task AllGood_ValueNotNull ()
		{
			int timesTried = 0;
			SetUpWithSettings (new WeatherClientSettings ("testApi"), () =>

			  {
				  timesTried++;
				  var response = new HttpResponseMessage (System.Net.HttpStatusCode.OK);
				  response.Content = new StringContent (MockHttpClient.GetLondonCurrentWeather (),
														Encoding.UTF8, "application/json");
				  return Task.FromResult (response);
			  });

			var weather = await client.GetByName ("London");

			Assert.IsNotNull (weather);
			Assert.AreEqual ("London", weather.Name);
			Assert.AreEqual (1, timesTried);
		}

		[Test]
		public async Task SecondRetry_AllGood_ValueNotNull ()
		{
			int timesTried = 0;
			SetUpWithSettings (new WeatherClientSettings ("testApi"), () =>

			{
				timesTried++;
				HttpResponseMessage responseMessage = new HttpResponseMessage (System.Net.HttpStatusCode.InternalServerError);
				if (timesTried == 2)
				{
					responseMessage = new HttpResponseMessage (System.Net.HttpStatusCode.OK);
					responseMessage.Content = new StringContent (MockHttpClient.GetLondonCurrentWeather (),
														  Encoding.UTF8, "application/json");
				}
				return Task.FromResult (responseMessage);
			});

			var weather = await client.GetByName ("London");

			Assert.IsNotNull (weather);
			Assert.AreEqual ("London", weather.Name);
			Assert.AreEqual (2, timesTried);
		}

	}
}
