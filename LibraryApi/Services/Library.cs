using System.Collections.Generic;
using LibraryApi.Models;

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
        private readonly List<Book> _booksInLibrary;

        /// <summary>
        /// Author's collection
        /// </summary>
        private readonly List<Author> _authors;

        /// <summary>
        /// Service collections initialize
        /// </summary>
        public Library()
        {
            _authors = new List<Author>();

            Author Greg = new Author("The Gratest", "A", 1984);
            Author John = new Author("Good", "B", 1978);

            _authors.Add(Greg);
            _authors.Add(John);
           
           _booksInLibrary = new List<Book>
            {
                new Book("The Gratest Book", 2000, Greg.Id),
                new Book("Good Book", 2005, John.Id),
                new Book("Book", 2010, John.Id)
            };
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
            return _booksInLibrary.Find((Book) => Book.Id == id);
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
        /// <param name="author">New Author's Id</
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
        #endregion

    }


}
