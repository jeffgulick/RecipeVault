using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeVault.Models;

namespace RecipeVault.Pages_Recipes
{
    public class IndexModel : PageModel
    {
        private readonly RecipeVault.Models.AppDbContext _context;

        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 5;
        public int TotalPages {get; set;}

        public IndexModel(RecipeVault.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; } = default!;

        public async Task OnGetAsync()
        {
            // Recipe = await _context.Recipes
            //     .Include(r => r.Category).ToListAsync();

            TotalPages = (int)Math.Ceiling(_context.Recipes.Count() / (double)PageSize);
    
            Recipe = await _context.Recipes.Include(r => r.Category!)
                .Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync(); 
        }
    }
}
