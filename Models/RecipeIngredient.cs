using System.ComponentModel.DataAnnotations;

namespace RecipeVault.Models;

public class RecipeIngredient
{
    public int IngredientID { get; set; } // CPK/FK
    public int RecipeID { get; set; } // CPK/FK
    public Recipe Recipe { get; set; } = default!; // Nav prop
    public Ingredient Ingredient { set; get; } = default!; // Nav prop
}