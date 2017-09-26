using OpenWeatherNet;
using System;

namespace OpenWeatherNet.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherClient client = new WeatherClient("");
            var weather = client.Current.GetByName("London").Result;
            Console.WriteLine(weather);
        }
    }
}
