using System.Net.Http;
using System.Text.Json;

namespace RecipeCommunityWebApp.ApiServices
{
    public abstract class ApiService
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly JsonSerializerOptions _jsonSerializerOptions;

        public ApiService(IHttpClientFactory httpClientFactory, JsonSerializerOptions jsonSerializerOptions)
        {
            _httpClientFactory = httpClientFactory;
            _jsonSerializerOptions = jsonSerializerOptions;
        }

        protected HttpClient GetHttpClient()
        {
            return _httpClientFactory.CreateClient("RecipeCommunityHttpClient");
        }
    }
}
