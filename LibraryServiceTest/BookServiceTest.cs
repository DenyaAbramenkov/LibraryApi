//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using LibraryApi.Models;
//using LibraryApi.Services;
//using System.Collections.Generic;
//using Moq;
//using System.Linq;

//namespace LibraryServiceTest
//{
//    [TestClass]
//    public class BookServiceTest
//    {
//        private ILibraryModelDbContext _db;

//        private ILibrary _library;

//        [ClassInitialize]
//        public static void Initialize(ILibraryModelDbContext context)
//        {

//        }

//        [TestMethod]
//        public void BookService_GetAllBooks_Correct()
//        {
//            //Arange
//            Mock<ILibraryModelDbContext> mock = new Mock<ILibraryModelDbContext>();
//            mock.Setup(m +> mock.bo)

//            //Act
//            ////List<Book> result = new Library(library).GetAllBook().ToList();

//            //Assert
//            CollectionAssert.AreEqual(_books, result);
//        }

//        [TestMethod]
//        public void BookService_GetBookById_Correct()
//        {
//            //Arange
//            var library = _data.Object;

//            //Act
//            Book result = new Library(library).GetBook(1);

//            //Assert
//            Assert.AreEqual(_books[0], result);
//        }

//        [TestMethod]
//        public void BookService_UpdateBook_Correct()
//        {
//            //Arange
//            var library = _data.Object;

//            //Act
//            Book updatedBook = new Book("New name", 2000, 10);
//            Book result = new Library(library).UpdateBook(1, updatedBook);

//            //Assert
//            Assert.AreEqual(updatedBook, result);
//        }

//        [TestMethod]
//        public void BookService_CreateBook_Correct()
//        {
//            //Arange
//            var dataForLib = _data.Object;
//            Library lib = new Library(dataForLib);

//            //Act
//            lib.CreateBook(new Book("", 2000, 6));
//            List<Book> result = lib.GetAllBook().ToList();
//            _books.Add(new Book("", 2000, 6));

//            //Assert
//            CollectionAssert.AreEqual(_books, result);
//        }

//        [TestMethod]
//        public void BookService_DeleteBook_Correct()
//        {
//            //Arange
//            var dataForLib = _data.Object;
//            Library lib = new Library(dataForLib);

//            //Act
//            lib.DeleteBook(1);
//            List<Book> result = lib.GetAllBook().ToList();
//            _books.Remove(_books[0]);

//            //Assert
//            CollectionAssert.AreEqual(_books, result);
//        }

//        private static Book[] BooksToCompare =
//        {
//            new Book { BookId = 1, Name = "Book1" },
//            new Book { BookId = 2, Name = "Book2" },
//            new Book { BookId = 3, Name = "Book3" },
//            new Book { BookId = 4, Name = "Book4" }
//        };


//    }
//}
