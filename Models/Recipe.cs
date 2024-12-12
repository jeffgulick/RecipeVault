using System.ComponentModel.DataAnnotations;

namespace RecipeVault.Models;

public class Recipe
{
    public int RecipeID { get; set; } // PK

    [StringLength(100, MinimumLength = 1)]
    [Display(Name = "Recipe Name")]
    public string RecipeName { get; set; } = string.Empty;

    [StringLength(500)]
    [Display(Name = "Description")]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Instructions")]
    public string Instructions { get; set; } = string.Empty;

    [Display(Name = "Cook Time")]
    public String CookTime { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public int CategoryID { get; set; } // FK
    public Category Category { get; set; } = default!; // Nav prop
    public IEnumerable<RecipeIngredient> RecipeIngredients { get; set; } = default!; // Nav prop
}