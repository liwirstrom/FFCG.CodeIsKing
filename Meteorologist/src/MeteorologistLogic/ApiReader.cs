using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MeteorologistLogic
{
    public class ApiReader
    {
        private static HttpClient httpClient = new HttpClient();

        public Task<HttpResponseMessage> GetAsyncFromApi(string uriString)
        {
            try
            {
                var uri = new Uri(uriString);
                var apiRespons = httpClient.GetAsync(uri);
                return apiRespons;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
