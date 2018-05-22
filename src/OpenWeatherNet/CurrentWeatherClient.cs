using OpenWeatherNet.Common;
using OpenWeatherNet.Interfaces;
using OpenWeatherNet.Model;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeatherNet
{
	/// <summary>
	/// Current weather client. Implements <see cref="ICurrentWeatherClient"/> and has 
	/// the basic methods to obtain current weather by city name, by city identifier, 
	/// by city coords and by city zipCode and CountryCode.
	/// </summary>
	public class CurrentWeatherClient : ClientBase, ICurrentWeatherClient
	{
		public CurrentWeatherClient (HttpClient client, WeatherClientSettings settings) : base (client, settings)
		{
		}

		protected override string ParamURL => "weather";

		public Task<CurrentWeather> GetByCoords (Coord coord, Units units = Units.Standard,
			Language language = Language.EN, CancellationToken token = default (CancellationToken))
		{
			return GetByCoords<CurrentWeather> (coord, units, language, token);
		}

		public Task<CurrentWeather> GetByID (int cityID, Units units = Units.Standard,
			Language language = Language.EN, CancellationToken token = default (CancellationToken))
		{
			return GetByID<CurrentWeather> (cityID, units, language, token);
		}

		public Task<CurrentWeather> GetByName (string cityName, Units units = Units.Standard,
			Language language = Language.EN, CancellationToken token = default (CancellationToken))
		{
			return GetByName<CurrentWeather> (cityName, units, language, token);
		}

		public Task<CurrentWeather> GetByZip (string zipCode, string countryCode, Units units = Units.Standard,
			Language language = Language.EN, CancellationToken token = default (CancellationToken))
		{
			return GetByZip<CurrentWeather> (zipCode, countryCode, units, language, token);
		}
	}
}
