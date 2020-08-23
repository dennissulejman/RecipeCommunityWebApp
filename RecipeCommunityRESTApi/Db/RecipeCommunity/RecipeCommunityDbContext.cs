using Microsoft.EntityFrameworkCore;
using RecipeCommunityRESTApi.Db.RecipeCommunity.Models;
using System.Reflection;

namespace RecipeCommunityRESTApi.Db.RecipeCommunity
{
    public partial class RecipeCommunityDbContext : DbContext
    {
        public RecipeCommunityDbContext()
        {
        }

        public RecipeCommunityDbContext(DbContextOptions<RecipeCommunityDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cuisine> Cuisines { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<RecipeCategory> RecipeCategories { get; set; }
        public virtual DbSet<RecipeFavorite> RecipeFavorites { get; set; }
        public virtual DbSet<RecipeImage> RecipeImages { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
