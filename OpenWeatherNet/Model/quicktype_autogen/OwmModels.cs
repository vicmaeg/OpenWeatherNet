// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var data = CurrentWeather.FromJson(jsonString);
//
// For POCOs visit quicktype.io?poco
//
using Newtonsoft.Json;
namespace OpenWeatherNet.Model
{
    public partial class CurrentWeather
    {
        [JsonProperty("coord")]
        public Coord Coord { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("cod")]
        public long Cod { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }
    }

    public partial class Forecast
    {
        [JsonProperty("cnt")]
        public long Cnt { get; set; }

        [JsonProperty("list")]
        public List[] List { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("cod")]
        public string Cod { get; set; }

        [JsonProperty("message")]
        public double Message { get; set; }
    }

    public partial class List
    {
        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("dt_txt")]
        public string DtTxt { get; set; }

        [JsonProperty("snow")]
        public Snow Snow { get; set; }

        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }

        [JsonProperty("rain")]
        public Rain Rain { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }
    }

    public partial class Coord
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }
    }

    public partial class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }

    public partial class Main
    {
        [JsonProperty("sea_level")]
        public double SeaLevel { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("grnd_level")]
        public double GrndLevel { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("temp_kf")]
        public double TempKf { get; set; }

        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }
    }

    public partial class Sys
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("sunrise")]
        public long Sunrise { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("message")]
        public double Message { get; set; }

        [JsonProperty("sunset")]
        public long Sunset { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("pod")]
        public string Pod { get; set; }
    }

    public partial class Weather
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }
    }

    public partial class Wind
    {
        [JsonProperty("deg")]
        public double Deg { get; set; }

        [JsonProperty("speed")]
        public double Speed { get; set; }
    }

    public partial class Rain
    {
        [JsonProperty("3h")]
        public double? The3h { get; set; }
    }

    public partial class Snow
    {
        [JsonProperty("3h")]
        public double? The3h { get; set; }
    }

    public partial class City
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("coord")]
        public Coord Coord { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}

