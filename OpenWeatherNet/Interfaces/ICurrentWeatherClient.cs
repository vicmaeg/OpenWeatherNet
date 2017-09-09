using System;
using OpenWeatherNet.Model;

namespace OpenWeatherNet.Interfaces
{
    public interface ICurrentWeatherClient
    {
        CurrentWeather GetByName (string cityName);
        CurrentWeather GetByID (int cityID);
        CurrentWeather GetByCoords (Coord coord);
        CurrentWeather GetByZip(int zipCode, string countryCode);
    }
}
