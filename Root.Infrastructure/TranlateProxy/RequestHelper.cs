using System.IO;
using System.Net;
using System.Text;

namespace Root.Infrastructure.TranlateProxy
{
	public static class RequestHelper
	{
		public static string Get(string apiAddress, string @params, string apikey)
		{
			var url = string.Format("{0}?{1}", apiAddress, @params);

			var request = WebRequest.Create(url);

			request.Method = "GET";
			request.Headers.Add("apikey", apikey);

			using (var response = request.GetResponse())
			{
				var responseStream = response.GetResponseStream();

				if (responseStream != null)
				{
					using (var streamReader = new StreamReader(responseStream, Encoding.UTF8))
					{
						return streamReader.ReadToEnd();
					}
				}
			}

			return string.Empty;
		}
	}
}
