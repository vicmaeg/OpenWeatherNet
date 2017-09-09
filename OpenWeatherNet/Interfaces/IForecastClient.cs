using System;
using OpenWeatherNet.Model;

namespace OpenWeatherNet.Interfaces
{
    public interface IForecastClient
    {
		Forecast GetByName(string cityName);
		Forecast GetByID(int cityID);
		Forecast GetByCoords(Coord coord);
		Forecast GetByZip(int zipCode, string countryCode);
    }
}
