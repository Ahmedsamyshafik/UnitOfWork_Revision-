using Microsoft.EntityFrameworkCore;

namespace Repo.Core.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorID);

            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<Book> books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
