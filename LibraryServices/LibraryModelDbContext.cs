namespace LibraryApi.Services
{
    using LibraryApi.Models;
    using LibraryServices.Models;
    using Microsoft.EntityFrameworkCore;

    public class LibraryModelDbContext:DbContext
    {
        public LibraryModelDbContext(DbContextOptions<LibraryModelDbContext> options)
             : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres{ get; set; }
        public DbSet<BookGenreMap> BookGenreMaps { get; set; }
        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure default schema
            //modelBuilder.HasDefaultSchema("Admin");

            //Map entity to table
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Author>().ToTable("Authors");
        }

    }
}
