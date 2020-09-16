using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeCommunityRESTApi.Db.RecipeCommunity;
using RecipeCommunityRESTApi.Db.RecipeCommunity.Models;

namespace RecipeCommunityRESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly RecipeCommunityDbContext _db;

        public CategoriesController(RecipeCommunityDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            return await _db.Categories
                .Include(category => category.RecipeCategories)
                    .ThenInclude(recipeCategory => recipeCategory.Recipe)
                    .ThenInclude(recipe => recipe.Images)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return await _db.Categories
                .Include(category => category.RecipeCategories)
                    .ThenInclude(recipeCategory => recipeCategory.Recipe)
                    .ThenInclude(recipe => recipe.Images)
                .FirstOrDefaultAsync(category => category.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Category), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _db.Entry(category).State = EntityState.Modified;

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
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var category = await _db.Categories.FindAsync(id);

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();

            return category;
        }
    }
}