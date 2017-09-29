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
            
            int numInput = PromptForNumber("Choose Option 1 to add a book.  " +
                "\nChoose Option 2 to list all books. " +
                "\nChoose Option 3 to save and exit");

            while (numInput <= 3)
            {
                if (numInput == 1)
                {
                    Console.WriteLine("You chose option 1. Add Book.");

                    Console.WriteLine("Enter the book title: ");
                    string bookTitle = Console.ReadLine();

                    Console.WriteLine("Enter the author: ");
                    string author = Console.ReadLine();

                    Console.WriteLine("Enter the ISBN: ");
                    string isbn = Console.ReadLine();

                    Console.WriteLine("Enter the publisher: ");
                    string publisher = Console.ReadLine();

                    Book a = new Book(bookTitle, author, isbn, publisher);
                    Console.WriteLine(bookTitle, author, isbn, publisher);

                    //return to menu
                    numInput = PromptForNumber("Choose Option 1 to add a book.  " +
                "\nChoose Option 2 to list all books. " +
                "\nChoose Option 3 to save and exit");
                  
                }
                else if (numInput == 2)
                {
                    //call the list book method
                    Console.WriteLine("You chose option 2");
                    Console.ReadLine();

                    //return to menu
                    numInput = PromptForNumber("Choose Option 1 to add a book.  " +
                "\nChoose Option 2 to list all books. " +
                "\nChoose Option 3 to save and exit");
                }
                else
                {
                    //save and exit
                    //to be removed later
                    Console.WriteLine("You chose option 3");

                    //exit
                    return;
                    
                }
            }
        }

        private static int PromptForNumber(string promptString = "Enter a number: ")
        {
            int num = 0;
            string input = "";

            while (!int.TryParse(input, out num) || (Convert.ToInt32(input) > 3))
            {
                Console.WriteLine(promptString);
                input = Console.ReadLine();
            }
            
            return num;
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

        //add book - enter title, author, isbn and publisher

        //public string addBook(string title, string author, string isbn, string publisher)
        //{
        //    Title = title;
        //    Author = author;
        //    Isbn = isbn;
        //    Publisher = publisher;
            
        //}
    }

    public class CardCatalog
    {
        private string _filename;
        private string Title;
        private string Author;
        private string Isbn;
        private string Publisher;

        public CardCatalog(string fileName)
        {

        }

        List<Book> myBooks = new List<Book>();

        //  after each book, we should save
        //list book - retrieve the list of books and display them


    }


}
