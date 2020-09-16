using System.IO;

namespace RecipeCommunityRESTApi.Db.RecipeCommunity.Models
{
    public partial class RecipeImage
    {
        public int RecipeId { get; set; }
        private string _imagePath;
        public string ImagePath 
        { 
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = Path.Combine(Constants.ImagesFilePath, RecipeId.ToString(), value);
            }
        }
        public int Position { get; set; }
    }
}
