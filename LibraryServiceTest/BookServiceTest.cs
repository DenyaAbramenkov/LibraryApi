using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryApi.Models;
using LibraryApi.Services;
using System.Collections.Generic;

namespace LibraryServiceTest
{
    [TestClass]
    public class BookServiceTest
    {
        /// <summary>
        /// The library Sercive to test
        /// </summary>
        private static ILibrary _library;

        /// <summary>
        /// Initializes the library Service for testing
        /// </summary>
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _library = new Library();
        }

      
        [TestMethod]
        public void TestGetAllBook()
        {
            List<Book> expected = new List<Book> {
                new Book("The Gratest Book", 2000, 1),
                new Book("Good Book", 2005, 2),
                new Book("Book", 2010, 2)
            };

            List<Book> actual = new List<Book>();
            foreach(Book book in _library.GetAllBook())
            {
                actual.Add(book);
            }

            CollectionAssert.AreEqual(actual, expected);
        }

       
        [TestMethod]
        [DataRow(1, "The Gratest Book", 2000, 1)]
        [DataRow(2, "Good Book", 2005, 2)]
        public void TestGetBook_Correct(int id, string name, int authorId, int year)
        {
            Book expected = new Book(name, year, authorId);

            Book actual = _library.GetBook(id);

            Assert.AreEqual(actual, expected);
        }

    }
}
