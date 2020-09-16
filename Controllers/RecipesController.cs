using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeCommunityRESTApi.Db.RecipeCommunity.Models;
using RecipeCommunityWebApp.ApiServices;

namespace RecipeCommunityWebApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ILogger<RecipesController> _logger;
        private readonly IRecipesService _recipesService;
        private readonly ICuisinesService _cuisinesService;

        public RecipesController(ILogger<RecipesController> logger, IRecipesService recipesService, ICuisinesService cuisinesService)
        {
            _logger = logger;
            _recipesService = recipesService;
            _cuisinesService = cuisinesService;
        }

        public async Task<IActionResult> RecipeBrowser()
        {
            return View(await _recipesService.GetRecipes());
        }

        public async Task<IActionResult> RecipeSearch(string recipesSearchInput)
        {
            if (recipesSearchInput is null)
            {
                return View(Enumerable.Empty<Recipe>());
            }

            ViewData[Constants.RecipesSearchInput] = recipesSearchInput;

            return View(await _recipesService.GetRecipesFromSearchInput(recipesSearchInput));
        }

        public async Task<IActionResult> RecipeView(int id)
        {
            return View(await _recipesService.GetRecipe(id));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var recipe = await _recipesService.GetRecipe(id);

            if (recipe is null)
            {
                return NotFound();
            }

            await GetCuisines();

            return View(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            try
            {
                await _recipesService.PutRecipe(recipe);
                return RedirectToAction(/*nameof(RecipeView), id*/);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InvalidOperationException();
            }
        }

        private async Task GetCuisines()
        {
            var cuisines = await _cuisinesService.GetCuisines();

            ViewBag.Cuisines = new SelectList(cuisines, "Id", "Name");
        }
    }
}
