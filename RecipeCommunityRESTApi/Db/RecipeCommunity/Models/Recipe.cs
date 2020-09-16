using System;
using System.Collections.Generic;

namespace RecipeCommunityRESTApi.Db.RecipeCommunity.Models
{
    public partial class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CuisineId { get; set; }
        public virtual Cuisine Cuisine { get; set; }
        public int UserId { get; set; }
        public string CreationDate { get; set; } = DateTime.Now.ToString();
        public int Clicks { get; set; }
        public virtual ICollection<RecipeImage> Images { get; set; } = new HashSet<RecipeImage>();
        public virtual ICollection<RecipeIngredient> Ingredients { get; set; } = new HashSet<RecipeIngredient>();
    }
}
