using System;

namespace QuickMartTraders
{
    /// <summary>
    /// Provides the entry point for the QuickMart Traders console application.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class is responsible for initializing the application,
    /// displaying the main menu, and routing user input to the
    /// appropriate transaction operations.
    /// </para>
    /// <para>
    /// The application runs in a continuous loop until the user
    /// explicitly selects the exit option.
    /// </para>
    /// </remarks>
    public class Program
    {
        #region Application Entry Point

        /// <summary>
        /// The main entry point of the QuickMart Traders application.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments supplied at application startup.
        /// Currently not used.
        /// </param>
        /// <remarks>
        /// <para>
        /// This method creates a single instance of
        /// <see cref="SaleTransaction"/> and uses it throughout the
        /// application lifecycle.
        /// </para>
        /// <para>
        /// User interaction is handled through a menu-driven
        /// console interface.
        /// </para>
        /// </remarks>
        

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
        #endregion
    }
}
