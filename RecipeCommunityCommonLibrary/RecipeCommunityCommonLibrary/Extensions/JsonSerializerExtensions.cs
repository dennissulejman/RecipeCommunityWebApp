using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecipeCommunityCommonLibrary.Extensions
{
    public static class JsonSerializerExtensions
    {
        public static async Task<string> SerializeAsync<T>(this T objectToSerialize, JsonSerializerOptions jsonSerializerOptions = null)
        {
            using var memoryStream = new MemoryStream();
            await JsonSerializer.SerializeAsync(memoryStream, objectToSerialize, jsonSerializerOptions);
            memoryStream.Position = 0;
            using var reader = new StreamReader(memoryStream);
            return await reader.ReadToEndAsync();
        }
    }
}
