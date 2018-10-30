using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryApi.Models;
using LibraryApi.Services;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace LibraryServiceTest
{
    [TestClass]
    public class BookServiceTest
    {

        private static Mock<IDataProvider> _data;

        private static List<Book> _books;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _books = new List<Book> {
                new Book("The Gratest Book", 2000, 1),
                new Book("Good Book", 2005, 2),
                new Book("Book", 2010, 2)
            };
            _data = new MockDataImitation().MockSetBooks(_books);
        }

        [TestMethod]
        public void GetAllBooksTest()
        {
            var library = _data.Object;

            List<Book> result = new Library(library).GetAllBook().ToList();

            CollectionAssert.AreEqual(_books, result);
        }

        [TestMethod]
        public void GetBookByIdTest()
        {
            var library = _data.Object;

            Book result = new Library(library).GetBook(1);

            Assert.AreEqual(_books[0], result);
        }

        [TestMethod]
        public void UpdateBookTest()
        {
            var library = _data.Object;

            Book updatedBook = new Book("New name", 2000, 10);
            Book result = new Library(library).UpdateBook(1, updatedBook);

            Assert.AreEqual(updatedBook, result);
        }

        [TestMethod]
        public void CreateBookTest()
        {
            var dataForLib = _data.Object;
            Library lib = new Library(dataForLib);

            lib.CreateBook(new Book("", 2000, 6));
            List<Book> result = lib.GetAllBook().ToList();
            _books.Add(new Book("", 2000, 6));
            
            CollectionAssert.AreEqual(_books, result);
        }

        [TestMethod]
        public void DeleteBookTest()
        {
            var dataForLib = _data.Object;
            Library lib = new Library(dataForLib);

            lib.DeleteBook(1);
            List<Book> result = lib.GetAllBook().ToList();
            _books.Remove(_books[0]);

            CollectionAssert.AreEqual(_books, result);
        }

    }
}
