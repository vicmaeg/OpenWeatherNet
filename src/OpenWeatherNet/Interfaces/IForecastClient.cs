using OpenWeatherNet.Model;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeatherNet.Interfaces
{
    public interface IForecastClient
    {
		Task<Forecast> GetByName(string cityName, CancellationToken token = default(CancellationToken));
		Task<Forecast> GetByID(int cityID, CancellationToken token = default(CancellationToken));
		Task<Forecast> GetByCoords(Coord coord, CancellationToken token = default(CancellationToken));
		Task<Forecast> GetByZip(int zipCode, string countryCode, CancellationToken token = default(CancellationToken));
    }
}
