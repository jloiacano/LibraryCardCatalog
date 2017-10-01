using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCardCatalog
{

    class CardCatalog
    {
        private string _filename;

        private List<Book> books = new List<Book>();

        //public static string serializationFile = @"c:\temp\" + _filename + ".bin";

        public CardCatalog(string filename)
        {
            //open the file if one exists and deserialize it to books

            //using (Stream stream = File.Open(serializationFile, FileMode.Open))
            //{
            //    BinaryFormatter bf = new BinaryFormatter();

            //    books = (List<Book>)bf.Deserialize(stream);
            //}
            //TODO maybe? should check and prompt user if they want to create a new file if one does not exists
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

