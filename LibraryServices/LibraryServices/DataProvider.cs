using System.Collections.Generic;
using LibraryApi.Models;
using LibraryServices.Models;

namespace LibraryApi.Services
{
    /// <summary>
    /// Class initializer data about Library.
    /// </summary>
    public class DataProvider:IDataProvider
    {
        public IEnumerable<Book> Books { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<Author> Authors { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<Genre> Genres { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<BookGenreMap> BookGenreMap { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<BookAuthorMap> BookAuthorMap { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        /// <summary>
        /// Set of books for using in Library.
        /// </summary>
        /// <param name="books">Books in Set.</param>
        public IEnumerable<Author> SetAuthors()
        {
            List<Author> authors = new List<Author>
            {
                //new Author("The Gratest", "A", 1984), 
                //new Author("Good", "B", 1978)
            };

            return authors;
        }

        /// <summary>
        /// Set of authors for using in Library.
        /// </summary>
        /// <param name="authors">Authors in Set.</param>
        public IEnumerable<Book> SetBooks()
        {
            List<Book> books = new List<Book>
            {
                //new Book("The Gratest Book", 2000),
                //new Book("Good Book", 2005),
                //new Book("Book", 2010)
            };

            return books;
        }

        /// <summary>
        /// Set of genress for using in Library.
        /// </summary>
        /// <param name="genres">Genres in Set.</param>
        public IEnumerable<Genre> SetGenre()
        {
            List<Genre> genres = new List<Genre>
            {
                new Genre("Comedy"),
                new Genre("Tragedy"),
                new Genre("Detective")
            };

            return genres;
        }

        /// <summary>
        /// Set connection Genre with Book.
        /// </summary>
        public IEnumerable<KeyValuePair<int, int>> SetBookGenreCon()
        {
            IEnumerable<KeyValuePair<int, int>> booksAndGenreConncetion = new List<KeyValuePair<int, int>>
            {
                new KeyValuePair<int, int>(1, 1),
                new KeyValuePair<int, int>(1, 2),
                new KeyValuePair<int, int>(1, 3),
                new KeyValuePair<int, int>(2, 2)
            };

            return booksAndGenreConncetion;
        }
    }
}
