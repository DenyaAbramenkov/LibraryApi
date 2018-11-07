using System.Collections.Generic;
using System.Collections;
using LibraryApi.Models;
using System.Linq;
using LibraryServices.Models;
using System;

namespace LibraryApi.Services
{
    public class Library : ILibrary
    {
        /// <summary>
        /// Initialize region.
        /// </summary>
        #region Initialize

        /// <summary>
        /// Library's constructor
        /// </summary>
        public Library(ILibraryModelDbContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Service context initialize.
        /// </summary>
        private ILibraryModelDbContext _db;

        #endregion

        #region BookRegion

        /// <summary>
        /// Create new Book in collection.
        /// </summary>
        /// <param name="book">New Book.</param>
        public void CreateBook(Book book)
        {
            try
            {
                _db.Books.Add(book);
                _db.SaveChanges();
            }
            catch (ArgumentException)
            {
                throw new NullReferenceException("Wrong arg's input");
            }
        }

        /// <summary>
        /// Delete Book by Id.
        /// </summary>
        /// <param name="id">Book's Id.</param>
        public void DeleteBook(int id)
        {
            Book bookToDelete = _db.Books.FirstOrDefault((book) => book.BookId == id);
            try
            {
                _db.Books.Remove(bookToDelete);
                _db.SaveChanges();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Can't find Book with such Id");
            } 
        }

        /// <summary>
        /// Return All Books.
        /// </summary>
        public IEnumerable<Book> GetAllBook()
        {
            return _db.Books.ToList();
        }

        /// <summary>
        /// Return Book by Id.
        /// </summary>
        /// <param name="id">Book's Id.</param>
        /// <returns></returns>
        public Book GetBook(int id)
        {
            Book book = _db.Books.FirstOrDefault((bookToFind) => bookToFind.BookId == id);
            try
            {
                return book;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Can't find Book with such Id");
            }
        }

        /// <summary>
        /// Update Book in collection
        /// </summary>
        /// <param name="id">Book's Id.</param>
        /// <param name="book">New Book info</param>
        /// <returns>Updated Book.</returns>
        public Book UpdateBook(int id, Book book)
        {
            Book bookToUpdate = _db.Books.FirstOrDefault((bookToFind) => bookToFind.BookId == id);
            try
            {
                bookToUpdate.Name = book.Name;
                bookToUpdate.YearOfPublishing = book.YearOfPublishing;
                _db.SaveChanges();
                return bookToUpdate;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Can't find Book with such Id");
            }
        }

        /// <summary>
        /// Delete Author from Book.
        /// </summary>
        /// <param name = "bookId" > Book's Id.</param>
        /// <returns>Updated Book without author.</returns>
        public void DeleteAutorFromBook(int id)
        {
            BookAuthorMap bookToUpdate = _db.BookAuthorMap.FirstOrDefault((book) => book.BookId == id);
            try
            {
                _db.BookAuthorMap.Remove(bookToUpdate);
                _db.SaveChanges();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Can't find Book with such Id, which has Author");
            }
        }

        /// <summary>
        /// Add Author To Book.
        /// </summary>
        /// <param name="bookId">Book's Id.</param>
        /// <param name="authorId">Author's Id.</param>
        /// <returns>New Book with added Author.</returns>
        public void AddAuthorToBook(int bookId, int authorId)
        {
            Book bookToUpdate = _db.Books.FirstOrDefault((book) => book.BookId == bookId);
            try
            {
                BookAuthorMap bookAuthor = new BookAuthorMap();
                bookAuthor.BookId = bookToUpdate.BookId;
                bookAuthor.AuthorId = authorId;
                _db.BookAuthorMap.Add(bookAuthor);
                _db.SaveChanges();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Can't find Book with such Id");
            }
          
        }

        /// <summary>
        /// Adds the genre to book.
        /// </summary>
        /// <param name="bookId">The book's Id.</param>
        /// <param name="genreId">The genre's Id.</param>
        /// <returns>Is added new genre to book.</returns>
        public void AddGenreToBook(int bookId, int genreId)
        {
            Book bookToUpdate = _db.Books.FirstOrDefault((book) => book.BookId == bookId);
            try
            {
                BookGenreMap bookGenre = new BookGenreMap();
                bookGenre.BookId = bookToUpdate.BookId;
                bookGenre.GenreId = genreId;
                _db.BookGenreMap.Add(bookGenre);
                _db.SaveChanges();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Can't find Book with such Id");
            }
        }

        //#endregion

        //#region AuthorRegion

        /// <summary>
        /// Return All Authors.
        /// </summary>
        public IEnumerable<Author> GetAllAuthors()
        {
            return _db.Authors.ToList();
        }

        /// <summary>
        /// Return Author by Id.
        /// </summary>
        /// <param name="id">Author's Id.</param>
        /// <returns>Author by Id.</returns>
        public Author GetAuthor(int id)
        {
            Author author = _db.Authors.FirstOrDefault((authorToFind) => authorToFind.AuthorId == id);
            try
            {
                return author;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Can't find Author with such Id");
            }
        }

        /// <summary>
        /// Update Author.
        /// </summary>
        /// <param name="id">Author's Id.</param>
        /// <param name="author">New Author.</
        public Author UpdateAuthor(int id, Author author)
        {
            Author authorToUpdate = _db.Authors.FirstOrDefault((authorToFind) => authorToFind.AuthorId == id);
            try
            {
                authorToUpdate.Name = author.Name;
                authorToUpdate.Surname = author.Surname;
                authorToUpdate.YearOfBirthday = author.YearOfBirthday;
                _db.SaveChanges();
                return authorToUpdate;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Can't find Author with such Id");
            }
        }

        /// <summary>
        /// Create new Author.
        /// </summary>
        /// <param name="author">New Author to add.</param>
        public void CreateAuthor(Author author)
        {
            try
            {
                _db.Authors.Add(author);
                _db.SaveChanges();
            }
            catch (ArgumentException)
            {
                throw new NullReferenceException("Wrong arg's input");
            };
        }

        /// <summary>
        /// Delete Author from collection.
        /// </summary>
        /// <param name="id">Author's Id.</param>
        public void DeleteAuthor(int id)
        {
            Author authorToDelete = _db.Authors.FirstOrDefault((authorToFind) => authorToFind.AuthorId == id);
            try
            {
                _db.Authors.Remove(authorToDelete);
                _db.SaveChanges();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Can't find Author with such Id");
            }
        }

        /// <summary>
        /// Get book's of author.
        /// </summary>
        /// <param name="authorId">Author's Id.</param>
        /// <returns></returns>
        public IEnumerable<Book> GetAuthorBooks(int authorId)
        {
            var result = from book in _db.Books
                         join booksofauthor in _db.BookAuthorMap on book.BookId equals booksofauthor.BookId
                         where booksofauthor.AuthorId == authorId
                         select book;
            try
            {
                return result;
            }
            catch(NullReferenceException)
            {
                throw new NullReferenceException("Can't find books of author with such Id");
            }
        }

        #endregion

        #region GenreRegion

        /// <summary>
        /// Return All Genres.
        /// </summary>
        public IEnumerable<Genre> GetAllGenres()
        {
            return _db.Genres.ToList();
        }

        /// <summary>
        /// Return Genre by Id.
        /// </summary>
        /// <param name="id">Genre's Id.</param>
        /// <returns>Genre by Id.</returns>
        public Genre GetGenre(int id)
        {
            Genre genre = _db.Genres.FirstOrDefault((genreToFind) => genreToFind.GenreId == id);
            try
            {
                return genre;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Can't find Genre with such Id");
            }
        }

        /// <summary>
        /// Create new Genre.
        /// </summary>
        /// <param name="genre">New Genre to add.</param>
        public void CreateGenre(Genre genre)
        {
            try
            {
                _db.Genres.Add(genre);
                _db.SaveChanges();
            }
            catch (ArgumentException)
            {
                throw new NullReferenceException("Wrong arg's input");
            };
        }

        /// <summary>
        /// Update Genre.
        /// </summary>
        /// <param name="id">Genre's Id.</param>
        /// <param name="genre">New Genre's Id.</param>
        /// <returns>Updated Genre.</returns>
        public Genre UpdateGenre(int id, Genre genre)
        {
            Genre genreToUpdate = _db.Genres.FirstOrDefault((genreToFind) => genreToFind.GenreId == id);
            try
            {
                genreToUpdate.Name = genre.Name;
                _db.SaveChanges();
                return genreToUpdate;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Can't find Genre with such Id");
            }
        }

        /// <summary>
        /// Delete Genre from collection.
        /// </summary>
        /// <param name="id">Genre's Id.</param>
        public void DeleteGenre(int id)
        {
            Genre genreToDelete = _db.Genres.FirstOrDefault((genreToFind) => genreToFind.GenreId == id);
            try
            {
                _db.Genres.Remove(genreToDelete);
                _db.SaveChanges();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Can't find Genre with such Id");
            }
        }

        /// <summary>
        /// All book's of this Genre.
        /// </summary>
        /// <param name="genreId">Genre's Id.</param>
        /// <returns></returns>
        public IEnumerable<Book> GetAllGenreBooks(int genreId)
        {
            var result = from book in _db.Books
                         join genresBook in _db.BookGenreMap on book.BookId equals genresBook.BookId
                         where genresBook.GenreId == genreId
                         select book;
            try
            {
                return result;
            }
            catch(NullReferenceException)
            {
                throw new NullReferenceException("Can't find no book with such Genres, Where Genres.Id = genreId");
            }
           
        }

        #endregion

    }
}
