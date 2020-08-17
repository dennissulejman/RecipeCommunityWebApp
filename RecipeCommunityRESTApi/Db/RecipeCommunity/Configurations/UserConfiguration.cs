using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeCommunityRESTApi.Db.RecipeCommunity.Models;

namespace RecipeCommunityRESTApi.Db.RecipeCommunity.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(e => e.EmailAddress)
                    .IsUnique();

            builder.HasIndex(e => e.Username)
                .IsUnique();

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.EmailAddress).IsRequired();

            builder.Property(e => e.PasswordHash).IsRequired();

            builder.Property(e => e.Username).IsRequired();
        }
    }
}
