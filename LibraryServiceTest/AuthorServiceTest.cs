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
        public void GetAllAuthorsTest()
        {
            var library = _data.Object;

            List<Author> result = new Library(library).GetAllAuthors().ToList();

            CollectionAssert.AreEqual(_authors, result);
        }

        [TestMethod]
        public void GetAuthorByIdTest()
        {
            var library = _data.Object;

            Author result = new Library(library).GetAuthor(1);

            Assert.AreEqual(_authors[0], result);
        }

        [TestMethod]
        public void UpdateAuthorTest()
        {
            var library = _data.Object;

            Author updatedAuthor = new Author("", "", 1999);
            Author result = new Library(library).UpdateAuthor(1, updatedAuthor);

            Assert.AreEqual(updatedAuthor, result);
        }

        [TestMethod]
        public void CreateAuthorTest()
        {
            var dataForLib = _data.Object;
            Library lib = new Library(dataForLib);

            lib.CreateAuthor(new Author("New name", "new surname", 1999));
            List<Author> result = lib.GetAllAuthors().ToList();
            _authors.Add(new Author("New name", "new surname", 1999));

            CollectionAssert.AreEqual(_authors, result);
        }

        [TestMethod]
        public void DeleteAuthorTest()
        {
            var dataForLib = _data.Object;
            Library lib = new Library(dataForLib);

            lib.DeleteAuthor(1);
            List<Author> result = lib.GetAllAuthors().ToList();
            _authors.Remove(_authors[0]);

            CollectionAssert.AreEqual(_authors, result);
        }

    }
}
