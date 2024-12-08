using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeVault.Models;

namespace RecipeVault.Pages_Recipes
{
    public class IndexModel : PageModel
    {
        private readonly RecipeVault.Models.AppDbContext _context;

        public IndexModel(RecipeVault.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Recipe = await _context.Recipes
                .Include(r => r.Category).ToListAsync();
        }
    }
}
