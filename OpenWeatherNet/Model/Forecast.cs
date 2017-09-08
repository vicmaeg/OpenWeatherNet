using System;
using System.Collections.Generic;

namespace OpenWeatherNet.Model
{
    public class Forecast
    {
		public string Cod { get; set; }
		public double Message { get; set; }
		public int Cnt { get; set; }
        public List<ForecastData> List { get; set; }
		public City City { get; set; }
    }
}
