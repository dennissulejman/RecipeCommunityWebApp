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
    public class MeasurementsController : ControllerBase
    {
        private readonly RecipeCommunityDbContext _db;

        public MeasurementsController(RecipeCommunityDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Measurement>>> GetAllMeasurements()
        {
            return await _db.Measurements.ToListAsync();
        }
    }
}