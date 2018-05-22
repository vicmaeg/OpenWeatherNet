using OpenWeatherNet.Common;
using OpenWeatherNet.Interfaces;
using OpenWeatherNet.Model;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace OpenWeatherNet
{
	/// <summary>
	/// Forecast client. Implements <see cref="IForecastClient"/> and has 
	/// the basic methods to obtain the 5 day / 3 hour forecast weather by city name, by city identifier, 
	/// by city coords and by city zipCode and CountryCode.
	/// </summary>
	public class ForecastClient : ClientBase, IForecastClient
	{
		public ForecastClient (HttpClient client, WeatherClientSettings settings) : base (client, settings)
		{
		}

		protected override string ParamURL => "forecasts";

		public Task<Forecast> GetByCoords (Coord coord, Units units = Units.Standard,
			Language language = Language.EN, CancellationToken token = default (CancellationToken))
		{
			return GetByCoords<Forecast> (coord, units, language, token);
		}

		public Task<Forecast> GetByID (int cityID, Units units = Units.Standard,
			Language language = Language.EN, CancellationToken token = default (CancellationToken))
		{
			return GetByID<Forecast> (cityID, units, language, token);
		}

		public Task<Forecast> GetByName (string cityName, Units units = Units.Standard,
			Language language = Language.EN, CancellationToken token = default (CancellationToken))
		{
			return GetByName<Forecast> (cityName, units, language, token);
		}

		public Task<Forecast> GetByZip (string zipCode, string countryCode, Units units = Units.Standard,
			Language language = Language.EN, CancellationToken token = default (CancellationToken))
		{
			return GetByZip<Forecast> (zipCode, countryCode, units, language, token);
		}
	}
}
