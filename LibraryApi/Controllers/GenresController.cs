using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using LibraryApi.Services;
using System.Collections.Generic;

namespace LibraryApi.Controllers
{
    /// <summary>
    /// Genre's controller.
    /// </summary>
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        /// <summary>
        /// Library Service.
        /// </summary>
        private readonly ILibrary _library;

        /// <summary>
        /// Service Initialize.
        /// </summary>
        /// <param name="library">Library.</param>
        public GenresController(ILibrary library)
        {
            _library = library;
        }

        /// <summary>
        /// Get all Genres.
        /// </summary>
        /// <returns>Result of Http request.</returns>
        [HttpGet]
        public IActionResult GetGenres()
        {
            List<Genre> genrelist = _library.GetAllGenres().ToList();
            if (genrelist.Count == 0)
            {
                return NotFound("Any book are not recorded!");
            }

            return Ok(genrelist);
        }

        /// <summary>
        /// Get Genre by Id.
        /// </summary>
        /// <param name="id">Genre's Id.</param>
        /// <returns>Result of Http request.</returns>
        [HttpGet("{id}", Name = "GetGenre")]
        public IActionResult GetGenre(int id)
        {
            var item = _library.GetAllGenres().ToList().Find((Genre) => Genre.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// Create New Genre.
        /// </summary>
        /// <param name="genre">Genre to create.</param>
        /// <returns>Result of Http request.</returns>
        [HttpPost]
        public IActionResult CreateGenre(Genre genre)
        {
            _library.CreateGenre(genre);
            return Created("genres", genre);
        }

        /// <summary>
        /// Update Genre.
        /// </summary>
        /// <param name="id">Genre's Id to update.</param>
        /// <param name="book">New Info.</param>
        /// <returns>Result of Http request</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, Genre genre)
        {
            var item = _library.GetGenre(id);
            if (item == null)
            {
                return NotFound();
            }
            _library.UpdateGenre(id, genre);
            return Ok();
        }

        /// <summary>
        /// Delete Genre.
        /// </summary>
        /// <param name="id">Genre's Id to delete.</param>
        /// <returns>Result of Http request.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            var item = _library.GetGenre(id);
            if (item == null)
            {
                return NotFound();
            }
            _library.DeleteGenre(id);
            return Ok();
        }

        /// <summary>
        /// Return all books of this Ganre.
        /// </summary>
        /// <param name="id">Ganre's Id.</param>
        /// <returns>Result of Http request.</returns>
        [HttpGet("{id}/books")]
        public IActionResult GetBooksOfGenre(int id)
        {
            List<Book> books = _library.GetAllGenreBooks(id).ToList();
            if (books.Count == 0)
            {
                return NotFound("There was nothing found");
            }

            return Ok(books);
        }
    }
}