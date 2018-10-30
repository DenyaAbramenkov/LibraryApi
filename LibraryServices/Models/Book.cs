namespace LibraryApi.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Model of Book for Library service
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Private counter for getting new Id of author
        /// </summary>
        private static int _counterForId = 0;

        /// <summary>
        /// Constructor for Book
        /// </summary>
        /// <param name="name">Name of Book</param>
        /// <param name="year">Year of publishing</param>
        /// <param name="authorId">Author's id, who wrote book</param>
        public Book(string name, int year, int? authorId = null)
        {
            Name = name;
            AuthorId = authorId;
            Year = year;
            Id = ++_counterForId;
        }

        /// <summary>
        /// Gets the Book's Id
        /// </summary> 
        public int Id { get; private set; }

        /// <summary>
        /// Gets or sets the Book's Name
        /// </summary>
        [Required(ErrorMessage = "Book's Name is required")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Book's AuthorId(Can be null)
        /// </summary>
        public int? AuthorId { get; set; }

        /// <summary>
        /// Gets or sets the Book's Year of publishing
        /// </summary>
        [Range (1500, 2018, ErrorMessage = "Book can't be published in that year!")]
        public int Year { get; set; }

        public override bool Equals(object book)
        {
            Book newbook = book as Book;
            if (this.Name == newbook.Name
             && this.AuthorId == newbook.AuthorId
             && this.Year == newbook.Year)
            {
                return true;
            }

            return false;
        }
    }
}
