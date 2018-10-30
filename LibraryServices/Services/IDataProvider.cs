using System.Collections.Generic;
using LibraryApi.Models;

namespace LibraryApi.Services
{
    /// <summary>
    /// Interece with data about Library
    /// </summary>
    public interface IDataProvider
    {

        /// <summary>
        /// Set of books for using in Library
        /// </summary>
        /// <param name="books">Books in Set</param>
        IEnumerable<Book> SetBooks();

        /// <summary>
        /// Set of authors for using in Library
        /// </summary>
        /// <param name="authors">Authors in Set</param>
        IEnumerable<Author> SetAuthors();

        /// <summary>
        /// Set of genress for using in Library
        /// </summary>
        /// <param name="genres">Genres in Set</param>
        IEnumerable<Genre> SetGenre();

        /// <summary>
        /// Set connection Genre with Book
        /// </summary>
        /// <param name="genres">Genres in Set</param>
        IEnumerable<KeyValuePair<int, int>> SetBookGenreCon();
    }
}
