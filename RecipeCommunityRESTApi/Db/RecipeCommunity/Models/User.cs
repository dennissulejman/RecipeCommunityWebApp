using System.Collections.Generic;

namespace RecipeCommunityRESTApi.Db.RecipeCommunity.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<RecipeFavorite> RecipeFavorites { get; set; } = new HashSet<RecipeFavorite>();
        public ICollection<Recipe> CreatedRecipes { get; set; } = new HashSet<Recipe>();
    }
}
