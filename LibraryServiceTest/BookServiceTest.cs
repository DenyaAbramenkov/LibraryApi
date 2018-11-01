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
        public void BookService_GetAllBooks_Correct()
        {
            //Arange
            var library = _data.Object;

            //Act
            List<Book> result = new Library(library).GetAllBook().ToList();

            //Assert
            CollectionAssert.AreEqual(_books, result);
        }

        [TestMethod]
        public void BookService_GetBookById_Correct()
        {
            //Arange
            var library = _data.Object;

            //Act
            Book result = new Library(library).GetBook(1);

            //Assert
            Assert.AreEqual(_books[0], result);
        }

        [TestMethod]
        public void BookService_UpdateBook_Correct()
        {
            //Arange
            var library = _data.Object;

            //Act
            Book updatedBook = new Book("New name", 2000, 10);
            Book result = new Library(library).UpdateBook(1, updatedBook);

            //Assert
            Assert.AreEqual(updatedBook, result);
        }

        [TestMethod]
        public void BookService_CreateBook_Correct()
        {
            //Arange
            var dataForLib = _data.Object;
            Library lib = new Library(dataForLib);

            //Act
            lib.CreateBook(new Book("", 2000, 6));
            List<Book> result = lib.GetAllBook().ToList();
            _books.Add(new Book("", 2000, 6));

            //Assert
            CollectionAssert.AreEqual(_books, result);
        }

        [TestMethod]
        public void BookService_DeleteBook_Correct()
        {
            //Arange
            var dataForLib = _data.Object;
            Library lib = new Library(dataForLib);

            //Act
            lib.DeleteBook(1);
            List<Book> result = lib.GetAllBook().ToList();
            _books.Remove(_books[0]);

            //Assert
            CollectionAssert.AreEqual(_books, result);
        }

    }
}
