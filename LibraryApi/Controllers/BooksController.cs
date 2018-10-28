﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LibraryApi.Services;
using LibraryApi.Models;

namespace LibraryApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        /// <summary>
        /// Library Service
        /// </summary>
        private readonly ILibrary _library;

        /// <summary>
        /// Service Initialize
        /// </summary>
        /// <param name="library">Library</param>
        public BooksController(ILibrary library)
        {
            _library = library;
        }

        /// <summary>
        /// Get all Books
        /// </summary>
        /// <returns>Result of Http request</returns>
        [HttpGet]
        public IActionResult GetBooks()
        {
            _library.GetAllBook();
            return Ok();
        }

        /// <summary>
        /// Get Book by Id
        /// </summary>
        /// <param name="id">Book's Id</param>
        /// <returns>Result of Http request</returns>
        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(int id)
        {
            var item = _library.GetAllBook().ToList().Find((book) => book.Id == id); 
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// Create New Book
        /// </summary>
        /// <param name="book">Book to create</param>
        /// <returns>Result of Http request</returns>
        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            _library.CreateBook(book);
            return Created("books", book);
        }

        /// <summary>
        /// Update Book
        /// </summary>
        /// <param name="id">Book's Id to update</param>
        /// <param name="book">New Info</param>
        /// <returns>Result of Http request</returns>
        [HttpPut]
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
        /// Delete Book
        /// </summary>
        /// <param name="id">Book's Id to delete</param>
        /// <returns>Result of Http request</returns>
        [HttpDelete]
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
    }
}