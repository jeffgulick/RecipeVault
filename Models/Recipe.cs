using System.ComponentModel.DataAnnotations;

namespace RecipeVault.Models;

public class Recipe
{
    public int RecipeID { get; set; } // PK

    [StringLength(100, MinimumLength = 1)]
    [Display(Name = "Recipe Name")]
    public string RecipeName { get; set; } = string.Empty;

    [StringLength(500)]
    [Display(Name = "Recipe Description")]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Recipe Instructions")]
    public string Instructions { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Recipe Cook Time")]
    [Range(typeof(TimeSpan), "00:00:00", "23:59:59")]
    public TimeSpan CookTime { get; set; }
    public int CategoryID { get; set; } // FK
    public Category Category { get; set; } = default!; // Nav prop
    public ICollection<RecipeIngredient>? RecipeIngredients { get; set; } = default!; // Nav prop
}