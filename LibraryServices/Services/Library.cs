using System.Collections.Generic;
using System.Collections;
using LibraryApi.Models;
using System.Linq;

namespace LibraryApi.Services
{
    public class Library : ILibrary
    {
        /// <summary>
        /// Initialize region
        /// </summary>
        #region Initialize

        /// <summary>
        /// Book's collection
        /// </summary>
        private List<Book> _booksInLibrary = new List<Book>();

        /// <summary>
        /// Author's collection
        /// </summary>
        private List<Author> _authors;

        /// <summary>
        /// Genre's collection
        /// </summary>
        private List<Genre> _genres;

        /// <summary>
        /// Genre's collection
        /// </summary>
        private readonly List<KeyValuePair<int, int>> _bookAndGenresConnection;

        /// <summary>
        /// Service collections initialize
        /// </summary>
        public Library(IDataProvider data)
        {
            _authors = data.SetAuthors().ToList();
            _booksInLibrary = data.SetBooks().ToList();
            _genres = data.SetGenre().ToList();
            _bookAndGenresConnection = data.SetBookGenreCon().ToList();
        }

        #endregion

        #region BookRegion

        /// <summary>
        /// Create new Book in collection
        /// </summary>
        /// <param name="book">New Book</param>
        public void CreateBook(Book book)
        {
            _booksInLibrary.Add(book);
        }

        /// <summary>
        /// Delete Book by Id
        /// </summary>
        /// <param name="id">Book's Id</param>
        public void DeleteBook(int id)
        {
            Book bookToDelete = _booksInLibrary.Find(Book => Book.Id == id);
            _booksInLibrary.Remove(bookToDelete);
        }

        /// <summary>
        /// Return All Books
        /// </summary>
        public IEnumerable<Book> GetAllBook()
        {
            foreach (Book book in _booksInLibrary)
            {
                yield return book;
            }
        }

        /// <summary>
        /// Return Book by Id
        /// </summary>
        /// <param name="id">Book's Id</param>
        /// <returns></returns>
        public Book GetBook(int id)
        {
            return _booksInLibrary.Find(Book => Book.Id == id);
        }

        /// <summary>
        /// Update Book in collection
        /// </summary>
        /// <param name="id">Book's Id</param>
        /// <param name="book">New Book info</param>
        /// <returns>Updated Book</returns>
        public Book UpdateBook(int id, Book book)
        {
            Book bookToUpdate = _booksInLibrary.Find((Book) => Book.Id == id);
            if (book != null)
            {
                bookToUpdate.Name = book.Name;
                bookToUpdate.AuthorId = book.AuthorId;
                bookToUpdate.Year = book.Year;
            }
            return bookToUpdate;
        }

        /// <summary>
        /// Delete Author from Book
        /// </summary>
        /// <param name="bookId">Book's Id</param>
        /// <returns>Updated Book without author</returns>
        public Book DeleteAutorFromBook(int id)
        {
            Book bookToUpdate = _booksInLibrary.Find((Book) => Book.Id == id);
            bookToUpdate.AuthorId = null;
            return bookToUpdate;
        }

        /// <summary>
        /// Add Author To Book
        /// </summary>
        /// <param name="bookId">Book's Id</param>
        /// <param name="authorId">Author's Id</param>
        /// <returns>New Book with added Author</returns>
        public Book AddAuthorToBook(int bookId, int authorId)
        {
            Book bookToUpdate = _booksInLibrary.Find((Book) => Book.Id == bookId);
            bookToUpdate.AuthorId = authorId;
            return bookToUpdate;
        }

        /// <summary>
        /// Adds the genre to book.
        /// </summary>
        /// <param name="book_id">The book identifier.</param>
        /// <param name="genre_id">The genre identifier.</param>
        /// <returns>Is added new link.</returns>
        public bool AddGenreToBook(int book_id, int genre_id)
        {
            bool result = false;

            if (GetBook(book_id) != null && _genres.Any((genre) => genre.Id == genre_id))
            {
                _bookAndGenresConnection.Add(new KeyValuePair<int, int>(book_id, genre_id));
                result = true;
            }
            return result;
        }

        #endregion

        #region AuthorRegion

        /// <summary>
        /// Return All Authors
        /// </summary>
        public IEnumerable<Author> GetAllAuthors()
        {
            foreach (Author author in _authors)
            {
                yield return author;
            }
        }

        /// <summary>
        /// Return Author by Id
        /// </summary>
        /// <param name="id">Author's Id</param>
        /// <returns>Author by Id</returns>
        public Author GetAuthor(int id)
        {
            return _authors.Find((Author) => Author.Id == id);
        }

        /// <summary>
        /// Update Author
        /// </summary>
        /// <param name="id">Author's Id</param>
        /// <param name="author">New Author</
        public Author UpdateAuthor(int id, Author author)
        {
            Author authorToUpdate = _authors.Find((Author) => Author.Id == id);
            if (authorToUpdate != null)
            {
                authorToUpdate.Name = author.Name;
                authorToUpdate.Surname = author.Surname;
                authorToUpdate.YearOfBirthday = author.YearOfBirthday;
            }
            return authorToUpdate;
        }

        /// <summary>
        /// Create new Author
        /// </summary>
        /// <param name="author">New Author to add</param>
        public void CreateAuthor(Author author)
        {
            _authors.Add(author);
        }

        /// <summary>
        /// Delete Author from collection
        /// </summary>
        /// <param name="id">Author's Id</param>
        public void DeleteAuthor(int id)
        {
            Author authorToDelete = _authors.Find(Author => Author.Id == id);
            foreach (Book book in _booksInLibrary)
            {
                if (book.AuthorId == id)
                {
                    _booksInLibrary.Remove(book);
                }
            }
            _authors.Remove(authorToDelete);
        }


        public IEnumerable<Book> GetAuthorBooks(int author_Id)
        {
            foreach (var authorBook in _booksInLibrary.Where(Book => Book.AuthorId == author_Id))
            {
                yield return authorBook;
            }
        }
        #endregion

        #region GenreRegion

        /// <summary>
        /// Return All Genres
        /// </summary>
        public IEnumerable<Genre> GetAllGenres()
        {
            foreach (Genre genre in _genres)
            {
                yield return genre;
            }
        }

        /// <summary>
        /// Return Genre by Id
        /// </summary>
        /// <param name="id">Genre's Id</param>
        /// <returns>Genre by Id</returns>
        public Genre GetGenre(int id)
        {
            return _genres.Find((Genre) => Genre.Id == id);
        }

        /// <summary>
        /// Create new Genre
        /// </summary>
        /// <param name="genre">New Genre to add</param>
        public void CreateGenre(Genre genre)
        {
            _genres.Add(genre);
        }

        /// <summary>
        /// Update Genre
        /// </summary>
        /// <param name="id">Genre's Id</param>
        /// <param name="genre">New Genre's Id</param>
        /// <returns>Updated Genre</returns>
        public Genre UpdateGenre(int id, Genre genre)
        {
            Genre genreToUpdate = _genres.Find((Genre) => Genre.Id == id);
            if (genre != null)
            {
                genreToUpdate.Name = genre.Name;
            }
            return genreToUpdate;
        }

        /// <summary>
        /// Delete Genre from collection
        /// </summary>
        /// <param name="id">Genre's Id</param>
        public void DeleteGenre(int id)
        {
            Genre genreToDelete = _genres.Find(Genre => Genre.Id == id);
            _genres.Remove(genreToDelete);
        }

        public IEnumerable<Book> GetAllGenreBooks(int genre_Id)
        {
            foreach (var genreBook in _bookAndGenresConnection.Where(bookGenre => bookGenre.Value == genre_Id))
            {
                yield return GetBook(genreBook.Key);
            }
        }

        #endregion

    }


}
