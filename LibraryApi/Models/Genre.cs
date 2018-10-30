namespace LibraryApi.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Model of Genre for Library service
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Private counter for getting new Id of genre
        /// </summary>
        private static int _counterForId = 0;

        public Genre(string name)
        {
            Name = name;
            Id = ++_counterForId;
        }

        /// <summary>
        /// Gets the Genres's Id
        /// </summary> 
        public int Id { get; private set; }

        /// <summary>
        /// Gets or sets the Genres's Name
        /// </summary>
        [Required(ErrorMessage = "Genre's Name is required")]
        public string Name { get; set; }
    }
}
