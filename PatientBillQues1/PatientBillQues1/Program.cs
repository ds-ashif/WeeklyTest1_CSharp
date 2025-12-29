using System;
namespace PatientBillQues1
{
    /// <summary>
    /// Contains the entry point for the MediSure Clinic Billing application.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This program provides a menu-driven console interface
    /// that allows users to create, view, and clear patient bills.
    /// </para>
    /// <para>
    /// The application runs continuously until the user selects
    /// the exit option.
    /// </para>
    /// </remarks>
    
    public class Program
    {
        #region Application Entry Point

        /// <summary>
        /// Main method where application execution begins.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed at startup.
        /// These are not used in the current implementation.
        /// </param>
        /// <remarks>
        /// <para>
        /// A single <see cref="PatientBill"/> object is created and reused
        /// to perform billing-related operations.
        /// </para>
        /// <para>
        /// User interaction is handled through a loop-driven
        /// menu system using console input and output.
        /// </para>
        /// </remarks>
        public static void Main(string[] args)
        {
            /// <summary>
            /// Creates a PatientBill object used to invoke billing operations.
            /// </summary>

            PatientBill bill =new PatientBill();

           
            while (true)
            {
                /// <summary>
                /// Displays the main menu options for the user.
                /// </summary>

                Console.WriteLine("================== MediSure Clinic Billing ==================");
                Console.WriteLine("1. Create New Bill (Enter Patient Details)");
                Console.WriteLine("2. View Last Bill");
                Console.WriteLine("3. Clear Last Bill");
                Console.WriteLine("4. Exit");


                /// <summary>
                /// Reads the user's menu selection from the console.
                /// </summary>
                Console.Write("Enter your option: ");
                int Option = int.Parse(Console.ReadLine());

                /// <summary>
                /// Executes the selected menu option using switch-case.
                /// </summary>
                switch (Option)
                {
                    case 1:
                        bill.CreateBill();
                        break;
                    case 2:
                        bill.ViewLastBill();
                        break;
                    case 3:
                        bill.ClearBill();
                        break;
                    case 4:
                        Console.WriteLine("Thank you. Application closed normally.");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please choose from choices Above.");
                        break;

                }

            }
        }
        #endregion
    }
}
