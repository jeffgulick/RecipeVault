using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeVault.Models;

namespace RecipeVault.Pages_Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger<DetailsModel> _logger;

        public DetailsModel(AppDbContext context, ILogger<DetailsModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Recipe Recipe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                            .Include(i => i.Category)
                            .Include(r => r.RecipeIngredients)
                            .ThenInclude(ri => ri.Ingredient)
                            .FirstOrDefaultAsync(m => m.RecipeID == id);


            if (recipe is not null)
            {
                Recipe = recipe!;

                return Page();
            }

            return NotFound();
        }
    }
}
