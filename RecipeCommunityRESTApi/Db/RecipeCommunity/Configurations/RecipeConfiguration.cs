using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeCommunityRESTApi.Db.RecipeCommunity.Models;

namespace RecipeCommunityRESTApi.Db.RecipeCommunity.Configurations
{
    internal class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(e => e.Id);

            builder.Property(e => e.CreationDate).IsRequired();

            builder.Property(e => e.Name).IsRequired();
        }
    }
}
