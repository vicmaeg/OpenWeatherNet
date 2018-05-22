
namespace OpenWeatherNet.Interfaces
{
	/// <summary>
	/// Weather client interface, used to obtain the Settings and the Current and
	/// Forecast client interfaces to be able to do api calls.
	/// </summary>
	public interface IWeatherClient
	{
		WeatherClientSettings Settings { get; }
		ICurrentWeatherClient Current { get; }
		IForecastClient Forecast { get; }
	}
}
