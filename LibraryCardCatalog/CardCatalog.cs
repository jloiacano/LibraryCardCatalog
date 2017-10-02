using System;
using System.Collections.Generic;
using System.IO;
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

            _filename = @"c:\temp\cardCatalog\" + filename + ".dat";

            if (File.Exists(_filename))
            {
                try
                {
                    using (Stream stream = File.Open(_filename, FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        books = (List<Book>)bf.Deserialize(stream);
                        stream.Close();
                        stream.Dispose();
                    }

                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("That file no longer exists. Please re-enter the file name to recreate" +
                        "or enter a new file name to create a new card catalog.");
                }
                using (Stream stream = File.Open(_filename, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    books = (List<Book>)bf.Deserialize(stream);
                    stream.Close();
                    stream.Dispose();
                }
            }
            else
            {
                try
                {
                using (Stream stream = File.Create(_filename, 32)){}
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("That file path seems to have been altered. " +
                        "Please try again. Sorry for the inconvenience.");
                }
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
            // serialize the List of Books and save them and exit the program.
            try
            {
            using (Stream stream = File.Open(_filename, FileMode.Create))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(stream, books);
            }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("That file seems to have been moved, misplaced, or deleted." +
                    "Sorry for the inconvenience. Please try again.");
            }

        }
    }
}

