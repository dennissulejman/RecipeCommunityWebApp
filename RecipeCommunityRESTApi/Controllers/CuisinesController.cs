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
    public class CuisinesController : ControllerBase
    {
        private readonly RecipeCommunityDbContext _db;

        public CuisinesController(RecipeCommunityDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuisine>>> GetAllCuisines()
        {
            return await _db.Cuisines.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cuisine>> GetCuisine(int id)
        {
            return await _db.Cuisines.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Cuisine>> PostCuisine(Cuisine cuisine)
        {
            await _db.Cuisines.AddAsync(cuisine);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Cuisine), new { id = cuisine.Id }, cuisine);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuisine(int id, Cuisine cuisine)
        {
            if (id != cuisine.Id)
            {
                return BadRequest();
            }

            _db.Entry(cuisine).State = EntityState.Modified;

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
        public async Task<ActionResult<Cuisine>> DeleteCuisine(int id)
        {
            var cuisine = await _db.Cuisines.FindAsync(id);

            _db.Cuisines.Remove(cuisine);
            await _db.SaveChangesAsync();

            return cuisine;
        }
    }
}
