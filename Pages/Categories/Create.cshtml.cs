using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.Data;
using RazorCrud.Model;

namespace RazorCrud.Pages.Categories
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name","Display Order cant match the Name" );
            }
            if (ModelState.IsValid)
            {
                await _context.Category.AddAsync(Category);
                await _context.SaveChangesAsync();
                TempData["success"] = "Category created"; 
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }

        }
    }
}
