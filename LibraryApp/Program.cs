namespace LibraryApp;
using BookLib;
using TaxLib;

/*
 *        Section:              CSCI 1260 - 090
 *        Name:                 Brycen Dunn (E00613421)
 *        Date:                 06/26/22
 *        Date last revised:    07/04/22
 *        Project name:         LibraryApp
 *        for:                  Project 1
 */

public static class Program
{
    public static void Main(string[] args)
    {
        Book firstBook = new Book();
        Book secondBook = new Book();
        Book thirdBook = new Book();
        TaxRate currentRate = new TaxRate();

        static void ShowHeading(string heading, char ch)                        // ShowHeading is a method that stylizes a console print.
                                                                                // It takes a string and a character as parameters, with
                                                                                // the character input padding on both sides of the string.
            
        {
            Console.WriteLine(new string(ch, heading.Length));
            Console.WriteLine(heading);
            Console.WriteLine(new string(ch, heading.Length));
        }

        void AllBookDetails()                                                   //AllBookDetails is a method that updates the console,
                                                                                //displaying relevant information for all books stored in the system.
        {
            Console.Clear();
            Console.WriteLine($"Book 1: {firstBook.Title}, {firstBook.Price:C}");
            Console.WriteLine($"Book 2: {secondBook.Title}, {secondBook.Price:C}");
            Console.WriteLine($"Book 3: {thirdBook.Title}, {thirdBook.Price:C}");
            Console.WriteLine($"Tax rate: {currentRate.TaxRatePropety * 100}%");
                
            Console.WriteLine("\n");
                
            Console.WriteLine($"Total Cost: {(firstBook.Price + secondBook.Price + thirdBook.Price):C}");
            
            var totalTax = currentRate.TaxRatePropety * (firstBook.Price + secondBook.Price + thirdBook.Price);
            
            Console.WriteLine($"Total tax: {totalTax:C}");
            
            var totalCostWithTax = firstBook.PriceWithTax(currentRate) + secondBook.PriceWithTax(currentRate) + thirdBook.PriceWithTax(currentRate);
            
            Console.WriteLine($"Total cost + tax: {totalCostWithTax:C}");
            
            ShowHeading("Press enter to go back to the main menu.", '-');
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                BookMenu();
            }

            Console.WriteLine();
        }

        static void LibraryExit()                                               //LibraryExit is a method that, when called, exits the application with a goodbye message.
        {
            Console.WriteLine("\n");
            ShowHeading("Thank you for using the Library Book Application", '-');
            
            Environment.Exit(0);
        }

        void BookInfo(Book book)                                                //BookInfo is a method that takes a book object as its parameter. It is used for both
                                                                                //validation of inputs and for console writes involving the title and price of the book.
        {
            Console.Clear();
            Console.WriteLine("\nPlease enter the title of the book: ");
            
            book.Title = Console.ReadLine() ?? throw new InvalidOperationException();
                
            while (book.Title == "")
            {
                Console.WriteLine("Title cannot be blank!");
                Thread.Sleep(1000);
                Console.WriteLine("\nPlease enter the title of the book: ");
                book.Title = Console.ReadLine() ?? throw new InvalidOperationException();
            }

            Console.WriteLine("Thank you, please enter the price of the book: ");
            
            book.Price = Convert.ToDouble(Console.ReadLine());
            while (book.Price is < 0)
            {
                Console.WriteLine("Price cannot be negative!");
                Thread.Sleep(1000);
                Console.WriteLine("\nPlease enter the price of the book: ");
                book.Price = Convert.ToDouble(Console.ReadLine());
            }
            while (book.Price is > 9999)
            {
                Console.WriteLine("Price cannot be greater than $9999!");
                Thread.Sleep(1000);
                Console.WriteLine("\nPlease enter the price of the book: ");
                book.Price = Convert.ToDouble(Console.ReadLine());
            }
            ShowHeading("Thank you, the book's price has been updated and added.", '-');
            Thread.Sleep(1000);
            Console.Clear();
            BookMenu();
        }

        void RemoveBook(Book book)                                              //RemoveBook is a method that takes a book object as its parameter. It is used to remove a book from the library system.
        {
            Console.Clear();
            Console.WriteLine($"You are removing {book.Title} from the library.");
            Console.WriteLine("Press 'y' to remove or 'n' to cancel: ");
            string answer = Console.ReadLine() ?? throw new InvalidOperationException();
            if (answer == "y" || answer == "Y")
            {
                book.Title = "No Book";
                book.Price = 0;
                ShowHeading("Book 1 has been removed.", '-');
                Thread.Sleep(1000);
                Console.Clear();
                BookMenu();
            }
            else if (answer == "n" || answer == "N")
            {
                Console.WriteLine("The book was not removed");
                Thread.Sleep(1000);
                Console.Clear();
                BookMenu();
            }
            else
            {
                Console.WriteLine("Invalid input!");
                Thread.Sleep(1000);
                Console.Clear();
                BookMenu();
            }
        }

        void SetTaxRate()                                                       //SetTaxRate sets the tax rate for the three book total. It also has input validation to
                                                                                //prevent the user from entering data in the wrong format.                                                               
        {
            Console.WriteLine($"Current tax rate is {currentRate.TaxRatePropety * 100}%");
            Console.WriteLine("Please enter the new tax rate: ");
            double newRate = Convert.ToDouble(Console.ReadLine());
            while (newRate is < 0)
            {
                Console.WriteLine("Please enter a value from 0 to 1 inclusive.");
                Console.WriteLine("Please enter the new tax rate: ");
                newRate = Convert.ToDouble(Console.ReadLine());
            }

            while (newRate > 1)
            {
                Console.WriteLine("Please enter a value from 0 to 1 inclusive: ");
                newRate = Convert.ToDouble(Console.ReadLine());
            }
                
            currentRate.SetTaxRate(newRate);
            ShowHeading("Tax rate has been updated.", '-');
            Thread.Sleep(1000);
            Console.Clear();
            BookMenu();
        }


        void BookMenu()                                                         //BookMenu is the main method of the program, serving as the main menu for the application.
                                                                                //It calls the choice methods when they are selected by the user.
        {
            ShowHeading("Welcome to the Library Book Main Menu", '-');
            Console.WriteLine("1 - Enter the Details about book 1");
            Console.WriteLine("2 - Enter the Details about book 2");
            Console.WriteLine("3 - Enter the Details about book 3");
            Console.WriteLine("4 - Remove book 1 details");
            Console.WriteLine("5 - Remove book 2 details");
            Console.WriteLine("6 - Remove book 3 details");
            Console.WriteLine("7 - Show all books");
            Console.WriteLine($"8 - Set the tax rate (current: {currentRate.TaxRatePropety * 100}%)");
            Console.WriteLine("9 - Exit");
            Console.Write("\nPlease make a choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            
            if (choice == 1)
            {
                BookInfo(firstBook);
            }
            
            if (choice == 2)
            {
                BookInfo(secondBook);
            }

            if (choice == 3)
            {
                BookInfo(thirdBook);
            }
            
            if (choice == 4)
            {
                RemoveBook(firstBook);
            }
            
            if (choice == 5)
            {
               RemoveBook(secondBook);
            }

            if (choice == 6)
            {
               RemoveBook(thirdBook);
            }

            if (choice == 7)
            {
                AllBookDetails();
            }

            if (choice == 8)
            {
                SetTaxRate();
            }

            if (choice == 9)
            { 
                LibraryExit();
            }

            else 
            {
                Console.WriteLine("Invalid input!");
                Thread.Sleep(1000);
                Console.Clear();
                BookMenu();
            }
        }
        
        BookMenu();
    }
}
