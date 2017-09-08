using System;
namespace OpenWeatherNet.Model
{
    public class City
    {
		public int ID { get; set; }
		public string Name { get; set; }
		public Coord Coord { get; set; }
		public string Country { get; set; }
    }
}
