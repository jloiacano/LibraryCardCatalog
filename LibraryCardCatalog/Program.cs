using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCardCatalog
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Book
    {

        private string Title;
        private string Author;
        private string Isbn;
        private string Publisher;

        public Book(string title, string author, string isbn, string publisher)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            Publisher = publisher;
        }
    }

    public class CardCatalog
    {
        private string _filename;

        public CardCatalog(string fileName)
        {

        }

        List<Book> myBooks = new List<Book>();

        //add book - enter title, author, isbn and publisher
        //  after each book, we should save
        //list book - retrieve the list of books and display them
    }

}
