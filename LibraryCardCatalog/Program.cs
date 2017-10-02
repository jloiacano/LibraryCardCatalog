using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace LibraryCardCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> bookList = new List<Book>();
            
            Console.WriteLine("Please Enter the Name of a File: ");
            string fileToUse = Console.ReadLine();

            CardCatalog currentCardCatalog = new CardCatalog(fileToUse);

            /*
            Stream stream = File.Open("BookList.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            bookList = (List<Book>)bf.Deserialize(stream);
            stream.Close();
            */

            Console.Clear();


            int checkForSaveAndExit = 0;
            while (checkForSaveAndExit != 3)
            {

                int numInput = PromptForNumber("Choose Option 1 to add a book.  " +
                "\nChoose Option 2 to list all books. " +
                "\nChoose Option 3 to save and exit");

                while (numInput <= 3)
                {
                    if (numInput == 1)
                    {
                        Console.WriteLine("You chose option 1. Add Book.");

                        Console.WriteLine("Enter the book title: ");
                        string title = Console.ReadLine();

                        Console.WriteLine("Enter the author: ");
                        string author = Console.ReadLine();

                        Console.WriteLine("Enter the ISBN: ");
                        string isbn = Console.ReadLine();

                        Console.WriteLine("Enter the publisher: ");
                        string publisher = Console.ReadLine();

                        //attempting to add a book to the list
                        Book aNewBook = new Book(title, author, isbn, publisher);
                        currentCardCatalog.AddBook(aNewBook);

                        //bookList.Add(new Book(title, author, isbn, publisher));

                        //return to menu
                        numInput = PromptForNumber("Choose Option 1 to add a book.  " +
                    "\nChoose Option 2 to list all books. " +
                    "\nChoose Option 3 to save and exit");

                    }
                    else if (numInput == 2)
                    {
                        //call the list book method
                        Console.WriteLine("You chose option 2");

                        foreach (var books in bookList)
                        {
                            Console.WriteLine(books);
                        }

                        Console.ReadLine();

                        //return to menu
                        numInput = PromptForNumber("Choose Option 1 to add a book.  " +
                    "\nChoose Option 2 to list all books. " +
                    "\nChoose Option 3 to save and exit");
                    }
                    else if (numInput == 3)
                    {
                                             
                        Console.WriteLine("You chose option 3");

                        /*
                        //Serialize the object into a data file.
                        Stream stream1 = File.Open("BookList.dat", FileMode.Create);
                        BinaryFormatter bf1 = new BinaryFormatter();

                        //Send the object to a data file.
                        bf.Serialize(stream, bookList);
                        stream.Close();
                        */

                        //exit
                        return;

                    }
                    else //if (numInput < 1 || numInput > 3 || numInput is string)
                    {
                        Console.WriteLine("That was not a valid entry.  Please enter a number between 1 and 3.");
                        numInput = PromptForNumber("Choose Option 1 to add a book.  " +
                    "\nChoose Option 2 to list all books. " +
                    "\nChoose Option 3 to save and exit");
                    }
                } Console.WriteLine("That was not a valid entry.  Please enter a number between 1 and 3.");
            }
        }
        private static int PromptForNumber(string promptString = "Enter a number: ")
        {
            int num = 0;
            string input = "";

            while (!int.TryParse(input, out num))
            {
                Console.WriteLine(promptString);
                input = Console.ReadLine();
            }
            
            return num;
        }

        /*
        private void SerializeBook()
        {
            //Serialize the object into a data file.
            Stream stream = File.Open("BookList.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            //Send the object to a data file.
            bf.Serialize(stream, Program.bookList);
            stream.Close();
        }

        private void DeSerializeBook()
        {
            //Read object data from data file.
            stream = File.Open("BookList.dat", FileMode.Open());
            BinaryFormatter bf = new BinaryFormatter();

            bookList = (bookList).bf.Deserialize(stream);
            Stream.Close();

            
        }
        */
    }
}
