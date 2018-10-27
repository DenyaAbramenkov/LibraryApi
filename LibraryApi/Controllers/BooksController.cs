using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryApi.Services;
using LibraryApi.Models;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILibrary _library;

        public BooksController(ILibrary library)
        {
            _library = library;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            _library.GetAllBook();
            return Ok();
        }
      
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var item = _library.GetAllBook().ToList().Find((book) => book.Id == id); 
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult PostBook(Book book)
        {
            _library.CreateBook(book);
            return Created("books", book);
        }

        [HttpPut]
        public IActionResult PutBook(int id, Book book)
        {
            var item = _library.GetBook(id);
            if (item == null)
            {
                return NotFound();
            }
            _library.UpdateBook(id, book);
            return Ok();
        }

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