using System;

namespace LibraryCardCatalog
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Please Enter the Name of a File: ");
            string fileToUse = Console.ReadLine();

            CardCatalog currentCardCatalog = new CardCatalog(fileToUse);
            
            Console.Clear();
            
            bool stillGoing = true;

            while (stillGoing == true)
            {
                Console.WriteLine("CHOOSE AN OPTION 1 - 3 for {0}\n\n1. List All books\n2. Add A Book\n3. Save and Exit", fileToUse);
                int userInput = MakeItTheRightInt(Console.ReadKey(true).KeyChar.ToString());
                switch (userInput)
                {
                    case 1:
                        currentCardCatalog.ListBooks();
                        break;
                    case 2:
                        currentCardCatalog.AddBook();
                        break;
                    case 3:
                        currentCardCatalog.Save();
                        stillGoing = false;
                        break;
                    default:
                        break;
                }
            }
            
        }

        private static int MakeItTheRightInt(string maybeAnInt)
        {
            int number;
            bool result = int.TryParse(maybeAnInt, out number);
            while (!result || number < 1 || number > 3)
            {
                Console.WriteLine("\n{0} is not a valid entry. Please enter a number between 1 and 3: ", number);
                string userInput = Console.ReadKey(true).KeyChar.ToString();
                result = int.TryParse(userInput, out number);
            }
            return number;
        }


    }
}
