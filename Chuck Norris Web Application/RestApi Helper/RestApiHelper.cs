using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Chuck_Norris_Web_Application.RestApi_Helper
{
    public class RestApiHelper
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private static readonly CancellationToken CancellationToken = default;

        /// <summary>
        /// GetAsycn Helper method to get from a WebApi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <returns>T</returns>
        public static async Task<T> GetAsync<T>(Uri uri)
        {
            var response = await HttpClient.GetAsync(uri, CancellationToken).ConfigureAwait(false);
            return await GetResult<T>(response);
        }

        /// <summary>
        /// Helper for common Async calls
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns>T</returns>
        private static async Task<T> GetResult<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NoContent)
                    //throw new HttpRequestException($"{response.StatusCode}:{response.Content}");
                    return default;

                await using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<T>(responseStream, cancellationToken: CancellationToken);
            }

            return default;
        }

    }
}
