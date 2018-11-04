using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryServices.Models
{
    public class BookGenreMap
    {
        /// <summary>
        /// Unic BookGenreMap.
        /// </summary>
        public int BookGenreMapId { get; set; }

        /// <summary>
        /// Book's Id as Foreighn Key.
        /// </summary>
        [ForeignKey("Books")]
        public int BookId { get; set; }

        /// <summary>
        /// Genre's Id as Foreighn Key.
        /// </summary>
        [ForeignKey("Genres")]
        public int AuthorId { get; set; }
    }
}
