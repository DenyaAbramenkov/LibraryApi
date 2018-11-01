using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryApi.Models;
using LibraryApi.Services;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace LibraryServiceTest
{
    [TestClass]
    public class AuthorServiceTest
    {
        private static Mock<IDataProvider> _data;

        private static List<Author> _authors;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _authors = new List<Author> {
                new Author("The Gratest", "A", 1984),
                new Author("Good", "B", 1978)
            };
            _data = new MockDataImitation().MockSetAuthors(_authors);
        }

        [TestMethod]
        public void AuthorService_GetAllAuthors_Correct()
        {
            //Arange
            var library = _data.Object;

            //Act
            List<Author> result = new Library(library).GetAllAuthors().ToList();

            //Assert
            CollectionAssert.AreEqual(_authors, result);
        }

        [TestMethod]
        public void AuthorService_GetAuthorById_Correct()
        {
            //Arange
            var library = _data.Object;

            //Act
            Author result = new Library(library).GetAuthor(1);

            //Assert
            Assert.AreEqual(_authors[0], result);
        }

        [TestMethod]
        public void AuthorService_UpdateAuthor_Correct()
        {
            //Arange
            var library = _data.Object;

            //Act
            Author updatedAuthor = new Author("", "", 1999);
            Author result = new Library(library).UpdateAuthor(1, updatedAuthor);

            //Assert
            Assert.AreEqual(updatedAuthor, result);
        }

        [TestMethod]
        public void AuthorService_CreateAuthor_Correct()
        {
            //Arange
            var dataForLib = _data.Object;
            Library lib = new Library(dataForLib);

            //Act
            lib.CreateAuthor(new Author("New name", "new surname", 1999));
            List<Author> result = lib.GetAllAuthors().ToList();
            _authors.Add(new Author("New name", "new surname", 1999));

            //Assert
            CollectionAssert.AreEqual(_authors, result);
        }

        [TestMethod]
        public void AuthorService_DeleteAuthor_Correct()
        {
            //Arange
            var dataForLib = _data.Object;
            Library lib = new Library(dataForLib);

            //Act
            lib.DeleteAuthor(1);
            List<Author> result = lib.GetAllAuthors().ToList();
            _authors.Remove(_authors[0]);

            //Assert
            CollectionAssert.AreEqual(_authors, result);
        }

    }
}
