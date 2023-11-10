using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.Data;
using RazorCrud.Model;

namespace RazorCrud.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
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

            Category dbCategory = _context.Category.Find(Category.Id);
            if (dbCategory != null)
            {
                _context.Category.Remove(dbCategory);
                await _context.SaveChangesAsync();
                TempData["success"] = "Category DELETED";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
