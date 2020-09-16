using System.Collections.Generic;

namespace RecipeCommunityRESTApi.Db.RecipeCommunity.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Clicks { get; set; }
        public virtual ICollection<RecipeCategory> RecipeCategories { get; set; } = new HashSet<RecipeCategory>();
    }
}
