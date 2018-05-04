using OpenWeatherNet.Common;
using System;
using System.IO;

namespace OpenWeatherNet.Sample
{
    class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine ("Getting Barcelona weather:");
            string apiKey = null;

            using (StreamReader sr = File.OpenText ("ApiKey.txt"))
            {
                apiKey = sr.ReadLine ();
            }
            WeatherClient client = new WeatherClient (apiKey);
            var weather = client.Current.GetByName ("Barcelona", Units.Metric, Language.ES).Result;
            if (!(weather is null))
            {
                Console.WriteLine ($"City Name: {weather.Name}");
                Console.WriteLine ($"Coords: lat={weather.Coord.Lat}, lon={weather.Coord.Lon}");
                Console.WriteLine ($"Temperature: {weather.Main.Temp}");
                Console.WriteLine ($"Max Temperature: {weather.Main.TempMax}");
                Console.WriteLine ($"Min Temperature: {weather.Main.TempMin}");
                Console.WriteLine ($"Visibility: {weather.Visibility}");
                Console.WriteLine ($"Wind Speed: {weather.Wind.Speed}");
                Console.WriteLine ($"Wind degrees: {weather.Wind.Deg}");
            }
            else
            {
                Console.WriteLine ($"Error obtaining Weather!");
            }

            Console.WriteLine ("Press Enter to exit");
            Console.Read ();
        }
    }
}
