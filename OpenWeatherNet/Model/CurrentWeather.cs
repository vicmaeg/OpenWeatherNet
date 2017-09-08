﻿using System;
using System.Collections.Generic;

namespace OpenWeatherNet.Model
{
    public class CurrentWeather
    {
		public Coord Coord { get; set; }
		public List<Weather> Weather { get; set; }
		public string Base { get; set; }
		public Main Main { get; set; }
		public int Visibility { get; set; }
		public Wind Wind { get; set; }
		public Clouds Clouds { get; set; }
		public int DT { get; set; }
		public Sys Sys { get; set; }
		public int ID { get; set; }
		public string Name { get; set; }
		public int Cod { get; set; }
    }
}
