using System;

namespace QuickMartTraders
{
    public class Program
    {
        /// <summary>
        /// Entry point of the QuickMart Traders application.
        /// Displays menu and handles user interaction.
        /// </summary>
        public static void Main(string[] args)
        {
            
            SaleTransaction transaction = new SaleTransaction();

            while (true)
            {
                Console.WriteLine("================== QuickMart Traders ==================");
                Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
                Console.WriteLine("2. View Last Transaction");
                Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your option: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        transaction.CreateTransaction();
                        break;

                    case 2:
                        transaction.ViewLastTransaction();
                        break;

                    case 3:
                        transaction.RecalculateProfitLoss();
                        break;

                    case 4:
                        Console.WriteLine("Thank you. Application closed normally.");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please choose a valid menu option.");
                        break;
                }
            }
        }
    }
}
