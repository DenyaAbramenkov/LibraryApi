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
        /// <summary>
        /// Book's collection
        /// </summary>
        private readonly List<Book> _booksInLibrary;

        /// <summary>
        /// Author's collection
        /// </summary>
        public IEnumerable<Author> _authors;

        /// <summary>
        /// Genre's collection
        /// </summary>
        private readonly List<Genre> _genres;

        /// <summary>
        /// Genre's collection
        /// </summary>
        private readonly List<KeyValuePair<int, int>> _bookAndGenresConnection;


        Mock<IDataProvider> mock = new Mock<IDataProvider>();
        readonly List<Book> books = new List<Book>();
        private static ILibrary _library;
        Mock<ILibrary> lib = new Mock<ILibrary>();

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Mock<IDataProvider> mock = new Mock<IDataProvider>();
            
            _library = new Library(mock.Object);
        }


        [TestMethod]
        public void TestGetAllBook()
        {
            mock.Setup(m => m.SetBooks()).Returns(books);

            CollectionAssert.AreEqual(books, _library.GetAllBook().ToList());
        }
        
       
        [TestMethod]
        
        public void TestGetBook_Correct()
        {
            Book actual = _library.GetBook(1);
            Book expected = new Book("The Gratest Book", 2000, 1);
            Assert.AreEqual(actual, expected);
        }

    }
}
