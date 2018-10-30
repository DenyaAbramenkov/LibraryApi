using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryApi.Models;
using LibraryApi.Services;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace LibraryServiceTest
{
    [TestClass]
    public class GenreServiceTest
    {

        private static Mock<IDataProvider> _data;

        private static List<Genre> _genres;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _genres = new List<Genre> {
                new Genre("Comedy"),
                new Genre("Tragedy"),
                new Genre("Detective")
            };
            _data = new MockDataImitation().MockSetGenres(_genres);
        }

        [TestMethod]
        public void GetAllGenresTest()
        {
            var library = _data.Object;

            List<Genre> result = new Library(library).GetAllGenres().ToList();

            CollectionAssert.AreEqual(_genres, result);
        }

        [TestMethod]
        public void GetGenreByIdTest()
        {
            var library = _data.Object;

            Genre result = new Library(library).GetGenre(1);

            Assert.AreEqual(_genres[0], result);
        }

        [TestMethod]
        public void UpdateGenreTest()
        {
            var library = _data.Object;

            Genre updatedGenre = new Genre("");
            Genre result = new Library(library).UpdateGenre(1, updatedGenre);

            Assert.AreEqual(updatedGenre, result);
        }

        [TestMethod]
        public void CreateGenreTest()
        {
            var dataForLib = _data.Object;
            Library lib = new Library(dataForLib);

            lib.CreateGenre(new Genre("New name"));
            List<Genre> result = lib.GetAllGenres().ToList();
            _genres.Add(new Genre("New name"));

            CollectionAssert.AreEqual(_genres, result);
        }

        [TestMethod]
        public void DeleteGenreTest()
        {
            var dataForLib = _data.Object;
            Library lib = new Library(dataForLib);

            lib.DeleteGenre(1);
            List<Genre> result = lib.GetAllGenres().ToList();
            _genres.Remove(_genres[0]);

            CollectionAssert.AreEqual(_genres, result);
        }

    }
}
