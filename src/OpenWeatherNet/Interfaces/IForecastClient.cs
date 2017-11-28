using OpenWeatherNet.Common;
using OpenWeatherNet.Model;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeatherNet.Interfaces
{
    public interface IForecastClient
    {
		Task<Forecast> GetByName(string cityName, Units units = Units.Standard,
            Language language = Language.EN, CancellationToken token = default(CancellationToken));
        Task<Forecast> GetByID(int cityID, Units units = Units.Standard,
           Language language = Language.EN, CancellationToken token = default(CancellationToken));
        Task<Forecast> GetByCoords(Coord coord, Units units = Units.Standard,
            Language language = Language.EN, CancellationToken token = default(CancellationToken));
        Task<Forecast> GetByZip(string zipCode, string countryCode, Units units = Units.Standard,
            Language language = Language.EN, CancellationToken token = default(CancellationToken));
    }
}
