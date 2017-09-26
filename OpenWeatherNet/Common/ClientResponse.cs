using System;
using System.Net.Http;

namespace OpenWeatherNet.Common
{
    public class ClientResponse
    {
        public ClientResponse(HttpResponseMessage response, Exception exception = null, bool timedOut = false)
        {
            Response = response;
            Exception = exception;
            TimedOut = timedOut;
        }

		/// <summary>
		/// Gets the underlying response from the server.
		/// </summary>
		public HttpResponseMessage Response { get; }

		/// <summary>
		/// Gets the exception thrown during the request, if any.
		/// </summary>
		public Exception Exception { get; }

		/// <summary>
		/// Gets whether the request timed out or was cancelled.
		/// </summary>
		public bool TimedOut { get; }
    }
}
