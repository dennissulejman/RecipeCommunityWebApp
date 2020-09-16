using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeCommunityRESTApi.Db.RecipeCommunity.Models;

namespace RecipeCommunityRESTApi.Db.RecipeCommunity.Configurations
{
    internal class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.Property(e => e.Id);

            builder.HasOne(e => e.Ingredient)
                .WithOne();

            builder.HasOne(e => e.Measurement)
                .WithOne();
        }
    }
}
