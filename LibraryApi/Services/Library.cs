using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApi.Models;

namespace LibraryApi.Services
{
    public class Library : ILibrary
    {
        private readonly List<Book> _booksInLibrary;
        public Library()
        {
            _booksInLibrary = new List<Book>
            {
                new Book("The Gratest Book", "The Gratest Author", 2000),
                new Book("Good Book", "Good Author", 2005),
                new Book("Book", "Author", 2010)
            };
        }

        public void CreateBook(Book book)
        {
            _booksInLibrary.Add(book);
        }

        public void DeleteBook(int id)
        {
            Book bookToDelete = _booksInLibrary.Find(Book => Book.Id == id);
            _booksInLibrary.Remove(bookToDelete);
        }

        public IEnumerable<Book> GetAllBook()
        {
            foreach (Book book in _booksInLibrary)
            {
                yield return book;
            }
        }

        public Book GetBook(int id)
        {
            return _booksInLibrary.Find((book) => book.Id == id);
        }

        public Book UpdateBook(int id, Book book)
        {
            Book bookToUpdate = _booksInLibrary.Find((bookToupadate) => bookToupadate.Id == id);
            if (book != null)
            {
                bookToUpdate.Name = book.Name;
                bookToUpdate.Author = book.Author;
                bookToUpdate.Year = book.Year;
            }
            return bookToUpdate;
        }
    }
}
