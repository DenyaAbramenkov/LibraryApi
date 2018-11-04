using System.Collections.Generic;
using LibraryApi.Models;
using LibraryServices.Models;

namespace LibraryApi.Services
{
    /// <summary>
    /// Interece with data about Library.
    /// </summary>
    public interface IDataProvider
    {
        IEnumerable<Book> Books { get; set; }
        IEnumerable<Author> Authors { get; set; }
        IEnumerable<Genre> Genres { get; set; }
        IEnumerable<BookGenreMap> BookGenreMap { get; set; }
        IEnumerable<BookAuthorMap> BookAuthorMap { get; set; }
    }
}
