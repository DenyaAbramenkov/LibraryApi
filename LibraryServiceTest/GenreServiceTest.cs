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
        public void GenreService_GetAllGenres_Correct()
        {
            //Arange
            var library = _data.Object;

            //Act
            List<Genre> result = new Library(library).GetAllGenres().ToList();

            //Assert
            CollectionAssert.AreEqual(_genres, result);
        }

        [TestMethod]
        public void GenreService_GetGenreById_Correct()
        {
            //Arange
            var library = _data.Object;

            //Act
            Genre result = new Library(library).GetGenre(1);

            //Assert
            Assert.AreEqual(_genres[0], result);
        }

        [TestMethod]
        public void GenreService_UpdateGenre_Correct()
        {
            //Arange
            var library = _data.Object;

            //Act
            Genre updatedGenre = new Genre("");
            Genre result = new Library(library).UpdateGenre(1, updatedGenre);

            //Assert
            Assert.AreEqual(updatedGenre, result);
        }

        [TestMethod]
        public void GenreService_CreateGenre_Correct()
        {
            //Arange
            var dataForLib = _data.Object;
            Library lib = new Library(dataForLib);

            //Act
            lib.CreateGenre(new Genre("New name"));
            List<Genre> result = lib.GetAllGenres().ToList();
            _genres.Add(new Genre("New name"));

            //Assert
            CollectionAssert.AreEqual(_genres, result);
        }

        [TestMethod]
        public void GenreService_DeleteGenre_Correct()
        {
            //Arange
            var dataForLib = _data.Object;
            Library lib = new Library(dataForLib);

            //Act
            lib.DeleteGenre(1);
            List<Genre> result = lib.GetAllGenres().ToList();
            _genres.Remove(_genres[0]);

            //Assert
            CollectionAssert.AreEqual(_genres, result);
        }

    }
}
