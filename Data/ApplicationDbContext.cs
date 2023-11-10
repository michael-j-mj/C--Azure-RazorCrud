using Microsoft.EntityFrameworkCore;
using RazorCrud.Model;

namespace RazorCrud.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Category> Category { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
