using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RecipeCommunityWebApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ILogger<RecipesController> _logger;

        public RecipesController(ILogger<RecipesController> logger)
        {
            _logger = logger;
        }

        public IActionResult RecipeBrowser()
        {
            return View();
        }

        public IActionResult RecipeSearch(string recipeSearchInput)
        {
            ViewData["RecipeSearchInput"] = recipeSearchInput;

            return View();
        }
    }
}
