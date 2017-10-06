using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

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

        protected abstract string ParamURL { get;}

        protected Task<T> GetByName<T>(string cityName, CancellationToken token)
        {
            var url = $"http://{settings.BaseURL}{settings.Version}/{ParamURL}?q={cityName}&appid={settings.AppId}";
            return ExecuteGetAsync<T>(url, token);
        }

        protected async Task<T> ExecuteGetAsync<T> (string url, CancellationToken token)
        {
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
    }
}
