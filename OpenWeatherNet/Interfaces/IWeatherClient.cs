using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherNet.Interfaces
{
    public interface IWeatherClient
    {
        WeatherClientSettings Settings { get; set; }
    }
}
