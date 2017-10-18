using OpenWeatherNet.Common;
using OpenWeatherNet.Model;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeatherNet.Interfaces
{
    public interface ICurrentWeatherClient
    {
        Task<CurrentWeather> GetByName (string cityName, Units units = Units.Standard,
            Language language = Language.EN, CancellationToken token = default(CancellationToken));
        Task<CurrentWeather> GetByID (int cityID, Units units = Units.Standard,
            Language language = Language.EN, CancellationToken token = default(CancellationToken));
        Task<CurrentWeather> GetByCoords (Coord coord, Units units = Units.Standard,
            Language language = Language.EN, CancellationToken token = default(CancellationToken));
        Task<CurrentWeather> GetByZip(string zipCode, string countryCode, Units units = Units.Standard,
            Language language = Language.EN, CancellationToken token = default(CancellationToken));
    }
}
