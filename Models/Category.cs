using System.ComponentModel.DataAnnotations;

namespace RecipeVault.Models;

public class Category 
{
    public int CategoryID { get; set; }

    [StringLength(100, MinimumLength = 1)]
    [Display(Name = "Category Name")]
    public string CategoryName { get; set; } = string.Empty;
}