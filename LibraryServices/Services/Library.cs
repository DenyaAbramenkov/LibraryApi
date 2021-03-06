﻿using System.Collections.Generic;
using System.Collections;
using LibraryApi.Models;
using System.Linq;

namespace LibraryApi.Services
{
    public class Library : ILibrary
    {
        /// <summary>
        /// Initialize region.
        /// </summary>
        #region Initialize

        /// <summary>
        /// Book's collection.
        /// </summary>
        private List<Book> _booksInLibrary = new List<Book>();

        /// <summary>
        /// Author's collection.
        /// </summary>
        private List<Author> _authors;

        /// <summary>
        /// Genre's collection.
        /// </summary>
        private List<Genre> _genres;

        /// <summary>
        /// Genre's collection.
        /// </summary>
        private readonly List<KeyValuePair<int, int>> _bookAndGenresConnection;

        /// <summary>
        /// Service collections initialize.
        /// </summary>
        public Library(IDataProvider data)
        {
            _authors = data.SetAuthors().ToList();
            _booksInLibrary = data.SetBooks().ToList();
            _genres = data.SetGenre().ToList();
            _bookAndGenresConnection = data.SetBookGenreCon().ToList();
        }

        #endregion

        #region BookRegion

        /// <summary>
        /// Create new Book in collection.
        /// </summary>
        /// <param name="book">New Book.</param>
        public void CreateBook(Book book)
        {
            _booksInLibrary.Add(book);
        }

        /// <summary>
        /// Delete Book by Id.
        /// </summary>
        /// <param name="id">Book's Id.</param>
        public void DeleteBook(int id)
        {
            Book bookToDelete = _booksInLibrary.Find((book) => book.Id == id);
            _booksInLibrary.Remove(bookToDelete);
        }

        /// <summary>
        /// Return All Books.
        /// </summary>
        public IEnumerable<Book> GetAllBook()
        {
            return _booksInLibrary;
        }

        /// <summary>
        /// Return Book by Id.
        /// </summary>
        /// <param name="id">Book's Id.</param>
        /// <returns></returns>
        public Book GetBook(int id)
        {
            return _booksInLibrary.Find((book) => book.Id == id);
        }

        /// <summary>
        /// Update Book in collection
        /// </summary>
        /// <param name="id">Book's Id.</param>
        /// <param name="book">New Book info</param>
        /// <returns>Updated Book.</returns>
        public Book UpdateBook(int id, Book book)
        {
            Book bookToUpdate = _booksInLibrary.Find((bookUpd) => bookUpd.Id == id);
            if (book != null)
            {
                bookToUpdate.Name = book.Name;
                bookToUpdate.AuthorId = book.AuthorId;
                bookToUpdate.Year = book.Year;
            }
            return bookToUpdate;
        }

        /// <summary>
        /// Delete Author from Book.
        /// </summary>
        /// <param name="bookId">Book's Id.</param>
        /// <returns>Updated Book without author.</returns>
        public Book DeleteAutorFromBook(int id)
        {
            Book bookToUpdate = _booksInLibrary.Find((book) => book.Id == id);
            bookToUpdate.AuthorId = null;
            return bookToUpdate;
        }

        /// <summary>
        /// Add Author To Book.
        /// </summary>
        /// <param name="bookId">Book's Id.</param>
        /// <param name="authorId">Author's Id.</param>
        /// <returns>New Book with added Author.</returns>
        public Book AddAuthorToBook(int bookId, int authorId)
        {
            Book bookToUpdate = _booksInLibrary.Find((book) => book.Id == bookId);
            bookToUpdate.AuthorId = authorId;
            return bookToUpdate;
        }

        /// <summary>
        /// Adds the genre to book.
        /// </summary>
        /// <param name="bookId">The book's Id.</param>
        /// <param name="genreId">The genre's Id.</param>
        /// <returns>Is added new link.</returns>
        public bool AddGenreToBook(int bookId, int genreId)
        {
            bool result = false;

            if (GetBook(bookId) != null && _genres.Any((genre) => genre.Id == genreId))
            {
                _bookAndGenresConnection.Add(new KeyValuePair<int, int>(bookId, genreId));
                result = true;
            }
            return result;
        }

        #endregion

        #region AuthorRegion

        /// <summary>
        /// Return All Authors.
        /// </summary>
        public IEnumerable<Author> GetAllAuthors()
        {
            return _authors;
        }

        /// <summary>
        /// Return Author by Id.
        /// </summary>
        /// <param name="id">Author's Id.</param>
        /// <returns>Author by Id.</returns>
        public Author GetAuthor(int id)
        {
            return _authors.Find((Author) => Author.Id == id);
        }

        /// <summary>
        /// Update Author.
        /// </summary>
        /// <param name="id">Author's Id.</param>
        /// <param name="author">New Author.</
        public Author UpdateAuthor(int id, Author author)
        {
            Author authorToUpdate = _authors.Find((Author) => Author.Id == id);
            if (authorToUpdate != null)
            {
                authorToUpdate.Name = author.Name;
                authorToUpdate.Surname = author.Surname;
                authorToUpdate.YearOfBirthday = author.YearOfBirthday;
            }
            return authorToUpdate;
        }

        /// <summary>
        /// Create new Author.
        /// </summary>
        /// <param name="author">New Author to add.</param>
        public void CreateAuthor(Author author)
        {
            _authors.Add(author);
        }

        /// <summary>
        /// Delete Author from collection.
        /// </summary>
        /// <param name="id">Author's Id.</param>
        public void DeleteAuthor(int id)
        {
            Author authorToDelete = _authors.Find(Author => Author.Id == id);
            foreach (Book book in _booksInLibrary)
            {
                if (book.AuthorId == id)
                {
                    _booksInLibrary.Remove(book);
                }
            }
            _authors.Remove(authorToDelete);
        }

        /// <summary>
        /// Get book's of author.
        /// </summary>
        /// <param name="authorId">Author's Id.</param>
        /// <returns></returns>
        public IEnumerable<Book> GetAuthorBooks(int authorId)
        {
            return _booksInLibrary.Where((book) => book.AuthorId == authorId);
        }
        #endregion

        #region GenreRegion

        /// <summary>
        /// Return All Genres.
        /// </summary>
        public IEnumerable<Genre> GetAllGenres()
        {
            return _genres;
        }

        /// <summary>
        /// Return Genre by Id.
        /// </summary>
        /// <param name="id">Genre's Id.</param>
        /// <returns>Genre by Id.</returns>
        public Genre GetGenre(int id)
        {
            return _genres.Find((Genre) => Genre.Id == id);
        }

        /// <summary>
        /// Create new Genre.
        /// </summary>
        /// <param name="genre">New Genre to add.</param>
        public void CreateGenre(Genre genre)
        {
            _genres.Add(genre);
        }

        /// <summary>
        /// Update Genre.
        /// </summary>
        /// <param name="id">Genre's Id.</param>
        /// <param name="genre">New Genre's Id.</param>
        /// <returns>Updated Genre.</returns>
        public Genre UpdateGenre(int id, Genre genre)
        {
            Genre genreToUpdate = _genres.Find((genreUpd) => genreUpd.Id == id);
            if (genre != null)
            {
                genreToUpdate.Name = genre.Name;
            }
            return genreToUpdate;
        }

        /// <summary>
        /// Delete Genre from collection.
        /// </summary>
        /// <param name="id">Genre's Id.</param>
        public void DeleteGenre(int id)
        {
            Genre genreToDelete = _genres.Find((genre) => genre.Id == id);
            _genres.Remove(genreToDelete);
        }

        /// <summary>
        /// All book's of this Genre.
        /// </summary>
        /// <param name="genreId">Genre's Id.</param>
        /// <returns></returns>
        public IEnumerable<Book> GetAllGenreBooks(int genreId)
        {
            foreach(KeyValuePair<int, int> keyValue in
                 _bookAndGenresConnection.Where(bookGenre => bookGenre.Value == genreId))
            {
                yield return _booksInLibrary.Find(book => book.Id == keyValue.Key);
            }
        }

        #endregion

    }
}
