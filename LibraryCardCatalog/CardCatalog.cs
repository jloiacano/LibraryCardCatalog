using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LibraryCardCatalog
{

    class CardCatalog
    {
        private string _filename;

        private List<Book> books = new List<Book>();

        // should be:
        //public static string serializationFile = @"c:\temp\" + _filename + ".bin";

        // temporary til I figure out how to access _filename;
        public static string serializationFile = @"c:\temp\" + "BOOKSDATA.dat" + ".bin";

        public CardCatalog(string filename)
        {
            _filename = @"c:\temp\" + filename + ".dat";


        }

        public void ListBooks()
        {
            // foreach loop of all the books in List using .toString()
            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }

        public void AddBook(Book book)
        {
            // add book object to books
            books.Add(book);
        }
        

        //public void Save()
        //{
        //    // serialize the List of Books and save them and exit the program.
        //    using (Stream stream = File.Open(serializationFile, FileMode.Create))
        //    {
        //        var bf = new BinaryFormatter();
        //        bf.Serialize(stream, books);
        //    }
        //    //TODO set up exiting the program

        //}
    }
}

