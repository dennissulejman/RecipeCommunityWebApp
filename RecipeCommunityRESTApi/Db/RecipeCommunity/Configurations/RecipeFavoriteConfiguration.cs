using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeCommunityRESTApi.Db.RecipeCommunity.Models;

namespace RecipeCommunityRESTApi.Db.RecipeCommunity.Configurations
{
    internal class RecipeFavoriteConfiguration : IEntityTypeConfiguration<RecipeFavorite>
    {
        public void Configure(EntityTypeBuilder<RecipeFavorite> builder)
        {
            builder.Property(e => e.Id);

            builder.HasOne(e => e.Recipe)
                .WithOne();
        }
    }
}
