using OpenWeatherNet.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeatherNet.Common
{
    public abstract class ClientBase
    {
        HttpClient client;
        WeatherClientSettings settings;

        protected ClientBase(HttpClient client, WeatherClientSettings settings)
        {
            this.client = client;
            this.settings = settings;
        }

        protected abstract string ParamURL { get; }

        protected Task<T> GetByName<T>(string cityName, Units units, Language language,
            CancellationToken token = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object> ();
            parameters.Add("q", cityName);
            parameters.Add("units", units);
            parameters.Add("lang", language);

            return ExecuteGetAsync<T> (parameters, token);
        }

        protected Task<T> GetByCoords<T>(Coord coords, Units units, Language language,
            CancellationToken token = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("lat", coords.Lat);
            parameters.Add("lon", coords.Lon);
            parameters.Add("units", units);
            parameters.Add("lang", language);

            return ExecuteGetAsync<T>(parameters, token);
        }

        protected Task<T> GetByID<T>(int cityID, Units units, Language language,
            CancellationToken token = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", cityID);
            parameters.Add("units", units);
            parameters.Add("lang", language);

            return ExecuteGetAsync<T>(parameters, token);
        }

        protected Task<T> GetByZip<T>(string zipCode, string countryCode, Units units, Language language,
           CancellationToken token = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("zip", $"{zipCode},{countryCode}");
            parameters.Add("units", units);
            parameters.Add("lang", language);

            return ExecuteGetAsync<T>(parameters, token);
        }

        protected async Task<T> ExecuteGetAsync<T> (IDictionary<string,object> queryParameters, CancellationToken token)
        {
            var url = CreateURL(queryParameters);
            var response = await GetAsync(url, token);
            //Determine a Response Action based on Settings
            if (response != null)
            {
                return await response.Response.Content.ReadAsAsync<T>();
            }
            return default(T);
        }

        protected async Task<ClientResponse> GetAsync(string url, CancellationToken token)
        {
            try
            {
                var response = await client.GetAsync(url, token);
                return new ClientResponse(response);
            }
            catch (TaskCanceledException ex)
            {
                return new ClientResponse(null, ex, true);
            }
            catch (Exception ex)
            {
                return new ClientResponse(null, ex);
            }
        }

        protected virtual string CreateURL (IDictionary<string,object> queryParameters)
        {
			var resourceBuilder = new StringBuilder();
			resourceBuilder
				.Append("http://")
				.Append(settings.BaseURL)
                .Append("/")
                .Append(settings.Version)
                .Append("/")
                .Append(ParamURL);

            var querySeparator = ParamURL.Contains("?") ? "&" : "?";
			if (queryParameters != null)
			{
				foreach (var kvp in queryParameters)
				{
					if (!(kvp.Value is string) && kvp.Value is IEnumerable enumerable)
					{
						foreach (var value in enumerable)
							AppendQueryValue(resourceBuilder, kvp.Key, value, ref querySeparator);
					}
					else
					{
						AppendQueryValue(resourceBuilder, kvp.Key, kvp.Value, ref querySeparator);
					}
				}
			}
            //Always add the appid query parameter at the end
            AppendQueryValue(resourceBuilder, "appid", settings.AppId, ref querySeparator);

            return resourceBuilder.ToString();
		}

		protected void AppendQueryValue(StringBuilder builder, string key, object value, ref string querySeparator)
		{
			if (value is Enum)
				value = value.ToString().ToLower();

			builder
				.Append(querySeparator)
				.Append(key)
				.Append("=")
				.Append(Uri.EscapeDataString(Convert.ToString(value, CultureInfo.InvariantCulture)));
			querySeparator = "&";
		}
    }
}
