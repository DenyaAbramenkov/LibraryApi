namespace LibraryApi.Services
{
    using LibraryApi.Models;
    using LibraryServices;
    using LibraryServices.Models;
    using Microsoft.EntityFrameworkCore;

    public class ILibraryModelDbContext:DbContext, LibraryServices.ILibraryModelDbContext
    { 
        public ILibraryModelDbContext(DbContextOptions<ILibraryModelDbContext> options)
             : base(options)
        {
        }

        public ILibraryModelDbContext()
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres{ get; set; }
        public DbSet<BookGenreMap> BookGenreMap { get; set; }
        public DbSet<BookAuthorMap> BookAuthorMap { get; set; }
    }
}
