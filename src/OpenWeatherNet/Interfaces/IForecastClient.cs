using OpenWeatherNet.Common;
using OpenWeatherNet.Model;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeatherNet.Interfaces
{
	/// <summary>
	/// Forecast client interface, contains the calls to obtain 5 day / 3 hour weather forecasts.
	/// </summary>
	public interface IForecastClient
	{
		/// <summary>
		/// Gets the 5 day / 3 hour forecast weather by city name.
		/// </summary>
		/// <returns>The by name.</returns>
		/// <param name="cityName">City name.</param>
		/// <param name="units">Units.</param>
		/// <param name="language">Language.</param>
		/// <param name="token">Token.</param>
		Task<Forecast> GetByName (string cityName, Units units = Units.Standard,
			Language language = Language.EN, CancellationToken token = default (CancellationToken));

		/// <summary>
		/// Gets the 5 day / 3 hour forecast weather by city identifier.
		/// </summary>
		/// <returns>The by identifier.</returns>
		/// <param name="cityID">City identifier.</param>
		/// <param name="units">Units.</param>
		/// <param name="language">Language.</param>
		/// <param name="token">Token.</param>
		Task<Forecast> GetByID (int cityID, Units units = Units.Standard,
		   Language language = Language.EN, CancellationToken token = default (CancellationToken));

		/// <summary>
		/// Gets the 5 day / 3 hour forecast weather by city coords
		/// </summary>
		/// <returns>The by coords.</returns>
		/// <param name="coord">Coordinate.</param>
		/// <param name="units">Units.</param>
		/// <param name="language">Language.</param>
		/// <param name="token">Token.</param>
		Task<Forecast> GetByCoords (Coord coord, Units units = Units.Standard,
			Language language = Language.EN, CancellationToken token = default (CancellationToken));

		/// <summary>
		/// Gets the 5 day / 3 hour forecast weather by city zip code and country code
		/// </summary>
		/// <returns>The by zip.</returns>
		/// <param name="zipCode">Zip code.</param>
		/// <param name="countryCode">Country code.</param>
		/// <param name="units">Units.</param>
		/// <param name="language">Language.</param>
		/// <param name="token">Token.</param>
		Task<Forecast> GetByZip (string zipCode, string countryCode, Units units = Units.Standard,
			Language language = Language.EN, CancellationToken token = default (CancellationToken));
	}
}
