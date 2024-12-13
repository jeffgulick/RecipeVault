using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeVault.Models;

namespace RecipeVault.Pages_Recipes
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(AppDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public string ImagePlaceholder { get; set; } = "img/CarouselTen.jpg";

        // Category ID to add to the recipe
        [BindProperty]
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required.")]
        public int CategoryIDToAdd { get; set; }

        // List of ingredient IDs to add to the recipe
        [BindProperty]
        [Display(Name = "Ingredients")]
        [Required(ErrorMessage = "At least one ingredient is required.")]
        public List<int> IngredientIDSToAdd { get; set; } = new List<int>();

        // Select lists for the dropdowns
        public SelectList CategoryNameSelectList { get; set; } = default!;
        public SelectList IngredientNameSelectList { get; set; } = default!;

        [BindProperty]
        public Recipe Recipe { get; set; } = new Recipe();

        public IActionResult OnGet()
        {
            PopulateSelectLists();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Assign the selected category to the recipe
            Recipe.CategoryID = CategoryIDToAdd;

            // Assign the selected ingredients to the recipe
            var ingredients = new List<RecipeIngredient>();
            foreach (var ingredientId in IngredientIDSToAdd)
            {
                var recipeIngredient = new RecipeIngredient
                {
                    IngredientID = ingredientId
                };
                ingredients.Add(recipeIngredient);
            }
            // Assign the ingredients to the recipe in the database
            Recipe.RecipeIngredients = ingredients;

            // Add the recipe to the database
            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Recipe '{Recipe.RecipeName}' created successfully with ID {Recipe.RecipeID}.");

            // Set TempData to trigger the modal
            TempData["SuccessMessage"] = $"Recipe '{Recipe.RecipeName}' created successfully!";
            return RedirectToPage("./Create");
        }

        private void PopulateSelectLists()
        {
            CategoryNameSelectList = new SelectList(_context.Categories.ToList(), "CategoryID", "CategoryName");
            IngredientNameSelectList = new SelectList(_context.Ingredients.ToList(), "IngredientID", "IngredientName");
        }
    }
}