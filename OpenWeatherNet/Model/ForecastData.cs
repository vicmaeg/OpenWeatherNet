using System;
using System.Collections.Generic;

namespace OpenWeatherNet.Model
{
    public class ForecastData
    {
		public int DT { get; set; }
		public Main Main { get; set; }
		public List<Weather> Weather { get; set; }
		public Clouds Clouds { get; set; }
		public Wind Wind { get; set; }
		public Snow Snow { get; set; }
        public Rain Rain { get; set; }
		public Sys Sys { get; set; }
		public string DT_txt { get; set; }
    }
}
