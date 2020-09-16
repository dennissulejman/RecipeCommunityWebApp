﻿namespace RecipeCommunityRESTApi.Db.RecipeCommunity.Models
{
    public partial class RecipeFavorite
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
        public int UserId { get; set; }
    }
}
