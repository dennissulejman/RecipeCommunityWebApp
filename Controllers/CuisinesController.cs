using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RecipeCommunityRESTApi.Db.RecipeCommunity.Models;
using RecipeCommunityWebApp.ApiServices;

namespace RecipeCommunityWebApp.Controllers
{
    public class CuisinesController : Controller
    {
        private readonly ILogger<CuisinesController> _logger;
        private readonly ICuisinesService _cuisinesService;

        public CuisinesController(ILogger<CuisinesController> logger, ICuisinesService cuisinesService)
        {
            _logger = logger;
            _cuisinesService = cuisinesService;
        }

        public async Task<IActionResult> Index()
        {
            var sel = new SelectList(await _cuisinesService.GetCuisines(), "ID", "Name");
            ViewData["Cuisines"] = sel;
            return View();
        }
    }
}
