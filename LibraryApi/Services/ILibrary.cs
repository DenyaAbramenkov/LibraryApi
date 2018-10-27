using LibraryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LibraryApi.Services
{
    public interface ILibrary
    {   
        IEnumerable<Book> GetAllBook();

        Book GetBook(int id);

        void CreateBook(Book book);

        Book UpdateBook(int id, Book book);

        void DeleteBook(int id);

    }
}
