namespace LibraryApi.Models
{
    using System.ComponentModel.DataAnnotations;
   

    /// <summary>
    /// Model of Book for Library service.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Private counter for getting new Id of author.
        /// </summary>
        private static int _counterForId = 0;

        /// <summary>
        /// Constructor for Book
        /// </summary>
        /// <param name="name">Name of Book.</param>
        /// <param name="year">Year of publishing.</param>
        /// <param name="authorId">Author's id, who wrote book.</param>
        //public Book(string name, int yearofpublishing)
        //{
        //    Name = name;
        //    YearOfPublishing = yearofpublishing;
        //    BookId = ++_counterForId;
        //}

        /// <summary>
        /// Gets the Book's Id.
        /// </summary> 
        public int BookId { get; private set; }

        /// <summary>
        /// Gets or sets the Book's Name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Book's Year of publishing.
        /// </summary>
        [Range (1500, 2018)]
        public int YearOfPublishing { get; set; }

        /// <summary>
        /// Equals override for Books compare.
        /// </summary>
        /// <param name="genre">Book to compare.</param>
        /// <returns>Result of comparattion.</returns>
        public override bool Equals(object book)
        {
            Book newBook = book as Book;
            if (this.Name == newBook.Name
             && this.YearOfPublishing == newBook.YearOfPublishing)
            {
                return true;
            }

            return false;
        }
    }
}
