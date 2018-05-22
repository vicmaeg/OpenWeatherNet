using OpenWeatherNet.Common;
using OpenWeatherNet.Model;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeatherNet.Interfaces
{
	/// <summary>
	/// Current weather client interface. Contains the calls to obtain the current
	/// weather.
	/// </summary>
	public interface ICurrentWeatherClient
	{
		/// <summary>
		/// Gets the Current weather by city name.
		/// </summary>
		/// <returns>The by name.</returns>
		/// <param name="cityName">City name.</param>
		/// <param name="units">Units.</param>
		/// <param name="language">Language.</param>
		/// <param name="token">Token.</param>
		Task<CurrentWeather> GetByName (string cityName, Units units = Units.Standard,
			Language language = Language.EN, CancellationToken token = default (CancellationToken));

		/// <summary>
		/// Gets the Current weather by city identifier.
		/// </summary>
		/// <returns>The by identifier.</returns>
		/// <param name="cityID">City identifier.</param>
		/// <param name="units">Units.</param>
		/// <param name="language">Language.</param>
		/// <param name="token">Token.</param>
		Task<CurrentWeather> GetByID (int cityID, Units units = Units.Standard,
			Language language = Language.EN, CancellationToken token = default (CancellationToken));

		/// <summary>
		/// Gets the Current weather by city coords
		/// </summary>
		/// <returns>The by coords.</returns>
		/// <param name="coord">Coordinate.</param>
		/// <param name="units">Units.</param>
		/// <param name="language">Language.</param>
		/// <param name="token">Token.</param>
		Task<CurrentWeather> GetByCoords (Coord coord, Units units = Units.Standard,
			Language language = Language.EN, CancellationToken token = default (CancellationToken));

		/// <summary>
		/// Gets the Current weather by city zip code and country code
		/// </summary>
		/// <returns>The by zip.</returns>
		/// <param name="zipCode">Zip code.</param>
		/// <param name="countryCode">Country code.</param>
		/// <param name="units">Units.</param>
		/// <param name="language">Language.</param>
		/// <param name="token">Token.</param>
		Task<CurrentWeather> GetByZip (string zipCode, string countryCode, Units units = Units.Standard,
			Language language = Language.EN, CancellationToken token = default (CancellationToken));
	}
}
