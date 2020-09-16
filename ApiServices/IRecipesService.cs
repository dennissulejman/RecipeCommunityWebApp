using RecipeCommunityRESTApi.Db.RecipeCommunity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeCommunityWebApp.ApiServices
{
    public interface IRecipesService
    {
        Task<Recipe> GetRecipe(int recipeId);
        Task<IEnumerable<Recipe>> GetRecipes();
        Task<IEnumerable<Recipe>> GetRecipesFromSearchInput(string recipesSearchInput);
        Task PutRecipe(Recipe recipe);
    }
}