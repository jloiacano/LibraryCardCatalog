using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

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
                try
                {
                    Directory.CreateDirectory(@"c:\temp\cardCatalog\");
                }
                catch (DirectoryNotFoundException)
                {

                    Console.WriteLine("That directory seems to have been deleted. Please re-enter a file name to recreate" +
                        "the directory.");

                }
            }

            _filename = @"c:\temp\cardCatalog\" + filename + ".json";

            if (File.Exists(_filename))
            {
                        books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(_filename));
            }
            else
            {
                books = new List<Book>();
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
            Console.WriteLine("\n");
        }

        public void AddBook()
        {
            // add book object to books
            Book book = new Book();
            Console.Clear();
            Console.WriteLine("Please enter the title of the book: ");
            book.Title = Console.ReadLine();
            while (book.Title == "")
            {
                Console.WriteLine("This field cannot be left empty. Please enter a valid title: ");
                book.Title = Console.ReadLine();
            }

            Console.WriteLine("Please enter the author of the book: ");
            book.Author = Console.ReadLine();
            while (book.Author == "")
            {
                Console.WriteLine("This field cannot be left empty. Please enter the author's name: ");
                book.Author = Console.ReadLine();
            }

            Console.WriteLine("Please enter the ISBN of the book: ");
            book.ISBN = Console.ReadLine();

            Console.WriteLine("Please enter the publisher of the book: ");
            book.Publisher = Console.ReadLine();

            books.Add(book);
            Console.Clear();
        }




        public void Save()
        {
            File.WriteAllText(_filename, JsonConvert.SerializeObject(books));
        }
    }
}

