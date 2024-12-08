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
    public TimeSpan CookTime { get; set; }
    public string ImageURL { get; set; } = string.Empty;
    public int CategoryID { get; set; } // FK
    public Category Category { get; set; } = default!; // Nav prop
    public IEnumerable<RecipeIngredient>? RecipeIngredients { get; set; } = default!; // Nav prop
}