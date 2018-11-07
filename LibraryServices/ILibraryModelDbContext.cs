using LibraryApi.Models;
using LibraryServices.Models;
using Microsoft.EntityFrameworkCore;


namespace LibraryServices
{
    interface ILibraryModelDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<BookGenreMap> BookGenreMap { get; set; }
        DbSet<BookAuthorMap> BookAuthorMap { get; set; }
    }
}
