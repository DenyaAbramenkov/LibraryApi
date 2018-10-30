namespace LibraryApi.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Model of Author for Library service
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Private counter for getting new Id of author
        /// </summary>
        private static int _counterForId = 0;

        /// <summary>
        /// Constructor for Author
        /// </summary>
        /// <param name="name">Name of Author</param>
        /// <param name="surname">Surname of Author</param>
        /// <param name="yearOfBirthday">Year of Birthday</param>
        public Author(string name, string surname, int yearOfBirthday)
        {
            Name = name;
            Surname = surname;
            YearOfBirthday = yearOfBirthday;
            Id = ++_counterForId;
        }

        /// <summary>
        /// Gets the Author's Id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets or sets the Author's Name
        /// </summary>
        [Required(ErrorMessage = "Author's Name is required")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Author's Surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the Author's Year of Birthday
        /// </summary>
        public int YearOfBirthday { get; set; }
    }
}
