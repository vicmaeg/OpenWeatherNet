using OpenWeatherNet.Interfaces;
using System;
using OpenWeatherNet.Model;
using System.Threading.Tasks;
using System.Net.Http;
using OpenWeatherNet.Common;
using System.Threading;

namespace OpenWeatherNet
{
    public class CurrentWeatherClient : ClientBase, ICurrentWeatherClient
    {
        public CurrentWeatherClient(HttpClient client, WeatherClientSettings settings) : base(client, settings)
        {
        }

        protected override string ParamURL => "weather";

        public Task<CurrentWeather> GetByCoords(Coord coord, CancellationToken token = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<CurrentWeather> GetByID(int cityID, CancellationToken token = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<CurrentWeather> GetByName(string cityName, CancellationToken token = default(CancellationToken))
        {
            return GetByName<CurrentWeather>(cityName, token);
        }

        public Task<CurrentWeather> GetByZip(int zipCode, string countryCode, CancellationToken token = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
