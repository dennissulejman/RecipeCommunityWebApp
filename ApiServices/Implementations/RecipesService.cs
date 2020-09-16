using RecipeCommunityCommonLibrary.Extensions;
using RecipeCommunityRESTApi.Db.RecipeCommunity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecipeCommunityWebApp.ApiServices.Implementations
{
    public class RecipesService : ApiService, IRecipesService
    {
        public RecipesService(IHttpClientFactory httpClientFactory, JsonSerializerOptions jsonSerializerOptions) : base(httpClientFactory, jsonSerializerOptions)
        {
        }

        public async Task<Recipe> GetRecipe(int recipeId)
        {
            var response = await GetHttpClient().GetAsync($"recipes/{recipeId}");

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Recipe>(responseStream, _jsonSerializerOptions);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            var response = await GetHttpClient().GetAsync("recipes");

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<Recipe>>(responseStream, _jsonSerializerOptions);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public async Task<IEnumerable<Recipe>> GetRecipesFromSearchInput(string recipesSearchInput)
        {
            recipesSearchInput = recipesSearchInput?.Trim();

            var recipes = await GetRecipes();

            return recipes.Where(recipe => recipe.Name.ToUpperInvariant().Contains(recipesSearchInput?.ToUpperInvariant()));
        }

        public async Task PutRecipe(Recipe recipe)
        {
            var recipeJsonMessage = await recipe.SerializeAsync();
            var recipeStringContent = new StringContent(recipeJsonMessage, Encoding.UTF8, RecipeCommunityCommonLibrary.Constants.JSONMediaType);

            try
            {
                await GetHttpClient().PutAsync($"recipes/{recipe.Id}", recipeStringContent);
            }
            catch (DBConcurrencyException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }
    }
}