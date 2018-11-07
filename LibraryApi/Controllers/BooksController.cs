using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LibraryApi.Services;
using LibraryApi.Models;
using System.Collections.Generic;

namespace LibraryApi.Controllers
{
    /// <summary>
    /// Book's controller.
    /// </summary>
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        /// <summary>
        /// Library Service.
        /// </summary>
        private readonly ILibrary _library;

        /// <summary>
        /// Service Initialize.
        /// </summary>
        /// <param name="library">Library..</param>
        public BooksController(ILibrary library)
        {
            _library = library;
        }

        /// <summary>
        /// Get all Books.
        /// </summary>
        /// <returns>Result of Http request.</returns>
        [HttpGet]
        public IActionResult GetBooks()
        {
            List<Book> booklist = _library.GetAllBook().ToList();
            if (booklist.Count == 0)
            {
                return NotFound("Any book are not recorded!");
            }

            return Ok(booklist);
        }

        /// <summary>
        /// Get Book by Id.
        /// </summary>
        /// <param name="id">Book's Id.</param>
        /// <returns>Result of Http request.</returns>
        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(int id)
        {
            var item = _library.GetBook(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// Create New Book.
        /// </summary>
        /// <param name="book">Book to create.</param>
        /// <returns>Result of Http request.</returns>
        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            _library.CreateBook(book);
            return Created("books", book);
        }

        /// <summary>
        /// Update Book.
        /// </summary>
        /// <param name="id">Book's Id to update.</param>
        /// <param name="book">New Info.</param>
        /// <returns>Result of Http request.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            var item = _library.GetBook(id);
            if (item == null)
            {
                return NotFound();
            }
            _library.UpdateBook(id, book);
            return Ok();
        }

        /// <summary>
        /// Delete Book.
        /// </summary>
        /// <param name="id">Book's Id to delete.</param>
        /// <returns>Result of Http request.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var item = _library.GetBook(id);
            if (item == null)
            {
                return NotFound();
            }
            _library.DeleteBook(id);
            return Ok();
        }

        /// <summary>
        /// Added Author to Book.
        /// </summary>
        /// <param name="book_id">Book's Id.</param>
        /// <param name="author_id">Author's Id.</param>
        /// <returns>Result of Http request.</returns>
        [HttpPost("{book_id}/authors/{author_id}")]
        public IActionResult AddAuthorToBook(int bookId, int authorId)
        {
            _library.AddAuthorToBook(bookId, authorId);
            return Ok("Added author to book");
        }

        [HttpDelete("{book_id}/authors")]
        public IActionResult RemoveAuthorfromBook(int bookId)
        {
            _library.DeleteAutorFromBook(bookId);
            return Ok("Author was deleted");
        }
        /// <summary>
        /// Adds genre to the book.
        /// </summary>
        /// <param name="book_id">The book id.</param>
        /// <param name="genre_id">The genre id.</param>
        /// <returns>Result of Http request.</returns>
        [HttpPost("{book_id}/genres/{genre_id}")]
        public IActionResult AddGenreToBook(int bookId, int genreId)
        {
            _library.AddGenreToBook(bookId, genreId);
            return Ok("New BookGenreMap was Added.");
        }

    }
}