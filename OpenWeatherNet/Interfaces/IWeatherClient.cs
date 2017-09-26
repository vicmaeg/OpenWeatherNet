
namespace OpenWeatherNet.Interfaces
{
    public interface IWeatherClient
    {
        WeatherClientSettings Settings { get; }
        ICurrentWeatherClient Current { get; }
        IForecastClient Forecast { get; }
    }
}
