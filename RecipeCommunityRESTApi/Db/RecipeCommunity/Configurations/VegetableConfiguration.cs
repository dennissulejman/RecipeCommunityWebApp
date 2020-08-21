using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeCommunityRESTApi.Db.RecipeCommunity.Models;

namespace RecipeCommunityRESTApi.Db.RecipeCommunity.Configurations
{
    internal class VegetableConfiguration : IEntityTypeConfiguration<Vegetable>
    {
        public void Configure(EntityTypeBuilder<Vegetable> builder)
        {
            builder.HasIndex(e => e.Name)
                    .IsUnique();

            builder.Property(e => e.Id);

            builder.Property(e => e.Name).IsRequired();
        }
    }
}
