using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.Data;
using RazorCrud.Model;

namespace RazorCrud.Pages.Categories
{
    public class IndexModel : PageModel
    {

        public IEnumerable<Category> Categories { get; set; }   
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext db)
        {
             _context= db;
            Categories = new List<Category>();
        }
        public void OnGet()
        {
            Categories = _context.Category; 
        }
    }
}
