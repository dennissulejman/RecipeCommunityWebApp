using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeCommunityRESTApi.Db.RecipeCommunity.Models;

namespace RecipeCommunityRESTApi.Db.RecipeCommunity.Configurations
{
    internal class RecipeImageConfigurations : IEntityTypeConfiguration<RecipeImage>
    {
        public void Configure(EntityTypeBuilder<RecipeImage> builder)
        {
            builder.HasKey(e => new { e.RecipeId });

            builder.Property(e => e.ImagePath).IsRequired();
        }
    }
}
