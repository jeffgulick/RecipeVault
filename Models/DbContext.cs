using Microsoft.EntityFrameworkCore;

namespace RecipeVault.Models;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }
    // Many to many relationship
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<RecipeIngredient>().HasKey(s => new {s.IngredientID, s.RecipeID});
        
    }

    public DbSet<Recipe> Recipes { get; set; } = default!;
    public DbSet<Ingredient> Ingredients { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = default!;
}