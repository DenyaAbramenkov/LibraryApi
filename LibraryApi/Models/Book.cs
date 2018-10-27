using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Models
{
    public class Book
    {
        private static int counterForId;

        public Book(string name, string author, int year)
        {
            Name = name;
            Author = author;
            Year = year;
            Id = ++counterForId;
        }

        public int Id;

        public string Name { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }    
    }
}
