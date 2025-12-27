using System;
namespace PatientBillQues1
{
    public class Program
    {
        /// <summary>
        /// Main method where application execution begins.
        /// Displays the menu repeatedly until the user chooses to exit.
        /// </summary>
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
    }
}
