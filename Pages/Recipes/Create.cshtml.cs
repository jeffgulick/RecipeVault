using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeVault.Models;

namespace RecipeVault.Pages_Recipes
{
    public class CreateModel : PageModel
    {
        private readonly RecipeVault.Models.AppDbContext _context;

        public CreateModel(RecipeVault.Models.AppDbContext context)
        {
            _context = context;
        }

       public IActionResult OnGet()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
