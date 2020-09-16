using RecipeCommunityRESTApi.Db.RecipeCommunity.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecipeCommunityWebApp.ApiServices.Implementations
{
    public class CuisinesService : ApiService, ICuisinesService
    {
        public CuisinesService(IHttpClientFactory httpClientFactory, JsonSerializerOptions jsonSerializerOptions) : base(httpClientFactory, jsonSerializerOptions)
        {
        }

        public async Task<IEnumerable<Cuisine>> GetCuisines()
        {
            var response = await GetHttpClient().GetAsync("cuisines");

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<Cuisine>>(responseStream, _jsonSerializerOptions);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
