using Microsoft.EntityFrameworkCore;

namespace Web.Database
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}