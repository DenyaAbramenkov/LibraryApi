using LibraryApi.Models;
using System.Collections.Generic;


namespace LibraryApi.Services
{
    public interface ILibrary
    {
        /// <summary>
        /// Region of Book's Services
        /// </summary>
        #region Book 

        /// <summary>
        /// Return All Books
        /// </summary>
        IEnumerable<Book> GetAllBook();

        /// <summary>
        /// Return Book by Id
        /// </summary>
        /// <param name="id">Book's Id</param>
        /// <returns></returns>
        Book GetBook(int id);

        /// <summary>
        /// Create new Book in collection
        /// </summary>
        /// <param name="book">New Book</param>
        void CreateBook(Book book);

        /// <summary>
        /// Update Book in collection
        /// </summary>
        /// <param name="id">Book's Id</param>
        /// <param name="book">New Book info</param>
        /// <returns>Updated Book</returns>
        Book UpdateBook(int id, Book book);

        /// <summary>
        /// Delete Book by Id
        /// </summary>
        /// <param name="id">Book's Id</param>
        void DeleteBook(int id);

        /// <summary>
        /// Delete Author from Book
        /// </summary>
        /// <param name="bookId">Book's Id</param>
        /// <returns>Updated Book without author</returns>
        Book DeleteAutorFromBook(int bookId);

        /// <summary>
        /// Add Author To Book
        /// </summary>
        /// <param name="bookId">Book's Id</param>
        /// <param name="authorId">Author's Id</param>
        /// <returns>New Book with added Author</returns>
        Book AddAuthorToBook(int bookId, int authorId);

        /// <summary>
        /// Adds the genre to book.
        /// </summary>
        /// <param name="book_id">The book identifier.</param>
        /// <param name="genre_id">The genre identifier.</param>
        /// <returns>Is added new link.</returns>
        bool AddGenreToBook(int book_id, int genre_id);

        #endregion

        /// <summary>
        /// Region of Author's Services
        /// </summary>
        #region Author

        /// <summary>
        /// Return All Authors
        /// </summary>
        IEnumerable<Author> GetAllAuthors();

        /// <summary>
        /// Return Author by Id
        /// </summary>
        /// <param name="id">Author's Id</param>
        /// <returns>Author by Id</returns>
        Author GetAuthor(int id);

        /// <summary>
        /// Create new Author
        /// </summary>
        /// <param name="author">New Author to add</param>
        void CreateAuthor(Author author);

        /// <summary>
        /// Update Author
        /// </summary>
        /// <param name="id">Author's Id</param>
        /// <param name="author">New Author's Id</param>
        /// <returns>Updated Author</returns>
        Author UpdateAuthor(int id, Author author);

        /// <summary>
        /// Delete Author from collection
        /// </summary>
        /// <param name="id">Author's Id</param>
        void DeleteAuthor(int id);

        /// <summary>
        /// Gets the books written by chozen author.
        /// </summary>
        /// <param name="author_Id">The author identifier.</param>
        /// <returns>Enumeration of books.</returns>
        IEnumerable<Book> GetAuthorBooks(int authorId);
        #endregion

        /// <summary>
        /// Region of Genre's Services
        /// </summary>
        #region Janre

        /// <summary>
        /// Return All Genres
        /// </summary>
        IEnumerable<Genre> GetAllGenres();

        /// <summary>
        /// Return Genre by Id
        /// </summary>
        /// <param name="id">Genre's Id</param>
        /// <returns>Genre by Id</returns>
        Genre GetGenre(int id);

        /// <summary>
        /// Create new Genre
        /// </summary>
        /// <param name="genre">New Genre to add</param>
        void CreateGenre(Genre genre);

        /// <summary>
        /// Update Genre
        /// </summary>
        /// <param name="id">Genre's Id</param>
        /// <param name="genre">New Genre's Id</param>
        /// <returns>Updated Genre</returns>
        Genre UpdateGenre(int id, Genre genre);

        /// <summary>
        /// Delete Genre from collection
        /// </summary>
        /// <param name="id">Genre's Id</param>
        void DeleteGenre(int id);

        /// <summary>
        /// Gets all books of supposed genre.
        /// </summary>
        /// <param name="genre_Id">The genre identifier.</param>
        /// <returns>Enumeration of books.</returns>
        IEnumerable<Book> GetAllGenreBooks(int genreId);

        #endregion










    }
}
