using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeVault.Models;

namespace RecipeVault.Pages_Recipes
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 8;
        public int TotalPages {get; set;}

        [BindProperty(SupportsGet = true)]
        public string CurrentSearch { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string CurrentSort { get; set; } = string.Empty;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var query = _context.Recipes!
                    .Include(i => i.Category)
                    .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                    .AsQueryable();

            switch(CurrentSort)
            {
                case "first_asc":
                    query = query.OrderBy(r => r.RecipeName);
                    break;
                case "first_desc":
                    query = query.OrderByDescending(r => r.RecipeName);
                    break;
                case "category_asc":
                    query = query.OrderBy(r => r.Category.CategoryName);
                    break;
                case "category_desc":
                    query = query.OrderByDescending(r => r.Category.CategoryName);
                    break;
            }

            // Search TODO: add search to pagination and details
            if (!string.IsNullOrEmpty(CurrentSearch))
            {
                query = query.Where(r => r.RecipeName.ToLower().Contains(CurrentSearch) ||
                                     r.Category.CategoryName.ToLower().Contains(CurrentSearch) ||
                                     r.RecipeIngredients!.Any(ri => ri.Ingredient.IngredientName.ToLower().Contains(CurrentSearch)));
            }
            
            TotalPages = (int)Math.Ceiling(_context.Recipes.Count() / (double)PageSize);
    
            Recipe = await query
                .Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync(); 
        }

    
    }
}
