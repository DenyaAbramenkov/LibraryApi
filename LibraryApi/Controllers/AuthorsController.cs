using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using LibraryApi.Services;

namespace LibraryApi.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        /// <summary>
        /// Library Sercice
        /// </summary>
        private readonly ILibrary _library;

        /// <summary>
        /// Service Initialize
        /// </summary>
        /// <param name="library">Library</param>
        public AuthorsController(ILibrary library)
        {
            _library = library;
        }

        /// <summary>
        /// Get all Author's
        /// </summary>
        /// <returns>Result of Http request</returns>
        [HttpGet]
        public IActionResult GetAuthors()
        {
            _library.GetAllAuthors();
            return Ok();
        }

        /// <summary>
        /// Get Author by Id
        /// </summary>
        /// <param name="id">Author's Id</param>
        /// <returns>Result of Http request</returns>
        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult GetAuthor(int id)
        {
            var item = _library.GetAllAuthors().ToList().Find((Author) => Author.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// Create new Author
        /// </summary>
        /// <param name="author">Author to create</param>
        /// <returns>Result of Http request</returns>
        [HttpPost]
        public IActionResult CreateAuthor(Author author)
        {
            _library.CreateAuthor(author);
            return Created("authors", author);
        }

        /// <summary>
        /// Update Author
        /// </summary>
        /// <param name="id">Author to update</param>
        /// <param name="author">New Info</param>
        /// <returns>Result of Http request</returns>
        [HttpPut]
        public IActionResult UpdateAuthor(int id, Author author)
        {
            var item = _library.GetAuthor(id);
            if (item == null)
            {
                return NotFound();
            }
            _library.UpdateAuthor(id, author);
            return Ok();
        }

        /// <summary>
        /// Delete Author
        /// </summary>
        /// <param name="id">Author's Id</param>
        /// <returns>Result of Http request</returns>
        [HttpDelete]
        public IActionResult DeleteAuthor(int id)
        {
            var item = _library.GetAuthor(id);
            if (item == null)
            {
                return NotFound();
            }
            _library.DeleteAuthor(id);
            return Ok();
        }
    }
}