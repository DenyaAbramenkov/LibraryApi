namespace LibraryApi.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;


    /// <summary>
    /// Model of Author for Library service.
    /// </summary>
    [Table("Authors")]
    public class Author
    {
        /// <summary>
        /// Private counter for getting new Id of author.
        /// </summary>
        private static int _counterForId = 0;


        /// <summary>
        /// Gets the Author's Id.
        /// </summary>
        public int AuthorId { get; private set; }

        /// <summary>
        /// Gets or sets the Author's Name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Author's Surname.
        /// </summary>
        [Required]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the Author's Year of Birthday.
        /// </summary>
        [Required]
        public int YearOfBirthday { get; set; }

        /// <summary>
        /// Equals override for Authors compare.
        /// </summary>
        /// <param name="genre">Author to compare.</param>
        /// <returns>Result of comparattion.</returns>
        public override bool Equals(object author)
        {
            Author newAuthor = author as Author;
            if (this.Name == newAuthor.Name
             && this.Surname == newAuthor.Surname
             && this.YearOfBirthday == newAuthor.YearOfBirthday)
            {
                return true;
            }

            return false;
        }
    }
}
