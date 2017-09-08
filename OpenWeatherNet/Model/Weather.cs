using System;
namespace OpenWeatherNet.Model
{
    public class Weather
    {
		public int ID { get; set; }
		public string Main { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }
    }
}
