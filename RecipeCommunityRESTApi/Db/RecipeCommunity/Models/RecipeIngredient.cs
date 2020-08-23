namespace RecipeCommunityRESTApi.Db.RecipeCommunity.Models
{
    public partial class RecipeIngredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public int MeasurementId { get; set; }
        public double MeasurementValue { get; set; }
    }
}
