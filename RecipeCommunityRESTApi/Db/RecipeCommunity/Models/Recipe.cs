using System;

namespace RecipeCommunityRESTApi.Db.RecipeCommunity.Models
{
    public partial class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CuisineId { get; set; }
        public int UserId { get; set; }
        public string CreationDate { get; set; } = DateTime.Now.ToString();
        public int Clicks { get; set; }
    }
}
