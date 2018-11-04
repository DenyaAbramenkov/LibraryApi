using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryServices.Models
{
    public class BookAuthorMap
    {
        /// <summary>
        /// Unic BookAthorMap.
        /// </summary>
        public int BookAuthorMapId { get; set; }

        /// <summary>
        /// Book's Id as Foreighn Key.
        /// </summary>
        [ForeignKey("Books")]
        public int BookId { get; set; }

        /// <summary>
        /// Authors's Id as Foreighn Key.
        /// </summary>
        [ForeignKey("Authors")]
        public int AuthorId { get; set; }

    }
}
