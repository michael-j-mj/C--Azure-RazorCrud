using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.Data;
using RazorCrud.Model;

namespace RazorCrud.Pages.Categories
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            if (id == null)
            {
            }
            else
            {
                Category = _context.Category.Find(id);
            }
        }

        public async Task<IActionResult> OnPost() 
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name","Display Order cant match the Name" );
            }
            if (ModelState.IsValid)
            {
                _context.Category.Update(Category);
                await _context.SaveChangesAsync();
                TempData["success"] = "Category Upodated";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }

        }
    }
}
