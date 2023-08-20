using Admin_BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin_BookAPI.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }
    }
}
