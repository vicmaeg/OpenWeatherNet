using OpenWeatherNet.Model;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeatherNet.Interfaces
{
    public interface ICurrentWeatherClient
    {
        Task<CurrentWeather> GetByName (string cityName, CancellationToken token = default(CancellationToken));
        Task<CurrentWeather> GetByID (int cityID, CancellationToken token = default(CancellationToken));
        Task<CurrentWeather> GetByCoords (Coord coord, CancellationToken token = default(CancellationToken));
        Task<CurrentWeather> GetByZip(int zipCode, string countryCode, CancellationToken token = default(CancellationToken));
    }
}
