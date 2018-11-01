namespace LibraryApi.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Model of Genre for Library service.
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Private counter for getting new Id of genre.
        /// </summary>
        private static int _counterForId = 0;

        public Genre(string name)
        {
            Name = name;
            Id = ++_counterForId;
        }

        /// <summary>
        /// Gets the Genres's Id.
        /// </summary> 
        public int Id { get; private set; }

        /// <summary>
        /// Gets or sets the Genres's Name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Equals override for Genres compare.
        /// </summary>
        /// <param name="genre">Genre to compare.</param>
        /// <returns>Result of comparattion.</returns>
        public override bool Equals(object genre)
        {
            Genre newGenre = genre as Genre;
            if (this.Name == newGenre.Name)
            {
                return true;
            }

            return false;
        }
    }
}
