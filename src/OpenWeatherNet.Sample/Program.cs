using System;
using System.IO;

namespace OpenWeatherNet.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = null;

            using (StreamReader sr = File.OpenText("ApiKey.txt"))
            {
                apiKey = sr.ReadLine();
                //you then have to process the string
            }
            WeatherClient client = new WeatherClient(apiKey);
            var weather = client.Current.GetByName("Barcelona").Result;
            Console.WriteLine(weather);
        }
    }
}
