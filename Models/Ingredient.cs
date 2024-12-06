using System.ComponentModel.DataAnnotations;

namespace RecipeVault.Models;

public class Ingredient
{
    public int IngredientID { get; set; } // PK

    [StringLength(100, MinimumLength = 1)]
    [Display(Name = "Ingredient Name")]
    public string IngredientName { get; set; } = string.Empty;
    public ICollection<RecipeIngredient>? RecipeIngredients { get; set; } = default!; // Nav prop
}