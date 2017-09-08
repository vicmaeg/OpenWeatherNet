using System;
namespace OpenWeatherNet.Model
{
    public class Sys
    {
		public int Type { get; set; }
		public int ID { get; set; }
		public double Message { get; set; }
		public string Country { get; set; }
		public int Sunrise { get; set; }
		public int Sunset { get; set; }
    }
}
