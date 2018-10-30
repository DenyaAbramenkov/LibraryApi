using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using LibraryApi.Models;
using LibraryApi.Services;

namespace LibraryServiceTest
{
    class MockDataImitation: Mock<IDataProvider>
    {
        public MockDataImitation MockSetAuthors(List<Author> authors)
        {
            Setup(library => library.SetAuthors()).Returns(authors);
            return this;
        }

        public MockDataImitation MockSetBooks(List<Book> books)
        {
            Setup(library => library.SetBooks()).Returns(books);
            return this;
        }

        public MockDataImitation MockSetGenres(List<Genre> genres)
        {
            Setup(library => library.SetGenre()).Returns(genres);
            return this;
        }

        public MockDataImitation MockSetBookGanreCon(List<KeyValuePair<int, int>> bookGanreCon)
        {
            Setup(library => library.SetBookGenreCon()).Returns(bookGanreCon);
            return this;
        }
    }
}
