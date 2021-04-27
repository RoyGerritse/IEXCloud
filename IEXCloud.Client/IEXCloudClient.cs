using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IEXCloud.Client
{
    public class IEXCloudClient
    {
        private readonly string _token;
        private const string BaseUrl = "https://cloud.iexapis.com/stable/";

        public IEXCloudClient(string token)
        {
            _token = token;
        }

        public async Task<List<IsinMapping>> RefDataIsin(string isin)
        {
            var url = $"{BaseUrl}/ref-data/isin";
            var queryParameters = new Dictionary<string, object>
            {
                {"token", _token},
                {"isin", isin}
            };

            return await CallUrl<List<IsinMapping>>(url, queryParameters);
        }

        private async Task<T> CallUrl<T>(string url, Dictionary<string, object>? queryParameters = null) where T : new()
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri(url)
            };
            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(mediaType);
            try
            {
                HttpResponseMessage response;
                if (queryParameters != null)
                {
                    var queryRequest = string.Join("&", queryParameters.Select((x) => x.Key + "=" + x.Value));
                    response = await client.GetAsync($"?{queryRequest}");
                }
                else
                {
                    response = await client.GetAsync("");
                }

                return await response.Content.ReadFromJsonAsync<T>() ?? throw new InvalidOperationException();
            }
            catch (HttpRequestException e)
            {
                if (e.Source != null)
                {
                    Console.WriteLine("HttpRequestException source: {0}", e.Source);
                }

                return new T();
            }
        }
    }
}