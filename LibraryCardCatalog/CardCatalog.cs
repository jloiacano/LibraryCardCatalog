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
       
        public CardCatalog(string filename)
        {
            if (!Directory.Exists(@"c:\temp\cardCatalog\"))
            {
                Directory.CreateDirectory(@"c:\temp\cardCatalog\");
            }

            _filename = @"c:\temp\cardCatalog\" + filename + ".dat";

            if (File.Exists(_filename))
            {
                using (Stream stream = File.Open(_filename, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    books = (List<Book>)bf.Deserialize(stream);
                    stream.Close();
                }
            }
            else
            {
                using (Stream stream = File.Create(_filename, 32)){}
            }
        }

        public void ListBooks()
        {
            // foreach loop of all the books in List using .toString()
            Console.Clear();
            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }
            Console.WriteLine("\n\n");
        }

        public void AddBook()
        {
            // add book object to books
            Book book = new Book();
            Console.Clear();
            Console.WriteLine("Please enter the title of the book: ");
            book.Title = Console.ReadLine();

            Console.WriteLine("Please enter the author of the book: ");
            book.Author = Console.ReadLine();

            Console.WriteLine("Please enter the ISBN of the book: ");
            book.ISBN = Console.ReadLine();

            Console.WriteLine("Please enter the publisher of the book: ");
            book.Publisher = Console.ReadLine();

            books.Add(book);
            Console.Clear();
        }
        

        public void Save()
        {
            // serialize the List of Books and save them and exit the program.
            using (Stream stream = File.Open(_filename, FileMode.Create))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(stream, books);
            }

        }
    }
}

