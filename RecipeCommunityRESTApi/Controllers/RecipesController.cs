using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeCommunityRESTApi.Db.RecipeCommunity;
using RecipeCommunityRESTApi.Db.RecipeCommunity.Models;

namespace RecipeCommunityRESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeCommunityDbContext _db;

        public RecipesController(RecipeCommunityDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetAllRecipes()
        {
            return await _db.Recipes
                .Include(recipe => recipe.Cuisine)
                .Include(recipe => recipe.Images)
                .Include(recipe => recipe.Ingredients)
                    .ThenInclude(recipeIngredient => recipeIngredient.Ingredient)
                .Include(recipe => recipe.Ingredients)
                    .ThenInclude(recipeIngredient => recipeIngredient.Measurement)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            return await _db.Recipes
                .Include(recipe => recipe.Cuisine)
                .Include(recipe => recipe.Images)
                .Include(recipe => recipe.Ingredients)
                    .ThenInclude(recipeIngredient => recipeIngredient.Ingredient)
                .Include(recipe => recipe.Ingredients)
                    .ThenInclude(recipeIngredient => recipeIngredient.Measurement)
                .FirstOrDefaultAsync(recipe => recipe.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            await _db.Recipes.AddAsync(recipe);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Recipe), new { id = recipe.Id }, recipe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            _db.Entry(recipe).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Recipe>> DeleteRecipe(int id)
        {
            var recipe = await _db.Recipes.FindAsync(id);

            _db.Recipes.Remove(recipe);
            await _db.SaveChangesAsync();

            return recipe;
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class RecipeImagesController : ControllerBase
    {
        private readonly RecipeCommunityDbContext _db;

        public RecipeImagesController(RecipeCommunityDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeImage>>> GetAllRecipeImages()
        {
            return await _db.RecipeImages
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeImage>> GetRecipeImage(int id)
        {
            return await _db.RecipeImages.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<RecipeImage>> PostRecipeImage(RecipeImage recipeImage)
        {
            await _db.RecipeImages.AddAsync(recipeImage);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(RecipeImage), new { id = recipeImage.ImagePath }, recipeImage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipeImage(RecipeImage recipeImage)
        {
            _db.Entry(recipeImage).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RecipeImage>> DeleteRecipeImage(int id)
        {
            var recipeImage = await _db.RecipeImages.FindAsync(id);

            _db.RecipeImages.Remove(recipeImage);
            await _db.SaveChangesAsync();

            return recipeImage;
        }
    }
}
