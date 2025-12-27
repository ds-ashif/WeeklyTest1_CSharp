using System;
using System.Collections.Generic;
using System.Text;

namespace PatientBillQues1
{
    /// <summary>
    /// Represents a patient's billing information, including charges, discounts, and insurance status, for use in a
    /// medical billing context.
    /// </summary>
    
    public class PatientBill
    {
        /// <summary>
        /// Represents the most recently generated patient bill, or null if no bill has been created.
        /// </summary>
        public static PatientBill? LastBill;
        public static bool HasLastBill = false;

        /// <summary>
        /// Gets or sets the unique identifier for the bill.
        /// </summary>

        public string? BillId { get; set; }
        public string? PatientName{get; set;}
        public bool HasInsurance { get; set; }
        public decimal ConsultationFee { get; set; }
        public decimal LabCharges { get; set; }
        public decimal MedicineCharges { get; set; }

        public decimal GrossAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalPayable { get; set; }

        /// <summary>
        /// Initializes a new instance of the PatientBill class.
        /// </summary>

        public PatientBill()
        {
            
        }

        /// <summary>
        /// Prompts the user to enter billing information and calculates the bill details for a patient.
        /// </summary>
        

        public void CreateBill()
        {
            Console.Write("Enter Bill Id: ");
            BillId = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(BillId))
            {
                Console.WriteLine("Bill Id cannot be empty.");
                return;
            }



            Console.Write("Enter Patient Name: ");
            PatientName=Console.ReadLine();
          

            Console.Write("Is the patient insured? (Y/N): ");
            string insuranceInput = Console.ReadLine();
            if (insuranceInput == "Y" || insuranceInput == "y")
            {
                HasInsurance = true;
            }
            else if(insuranceInput == "N" || insuranceInput == "n")
            {
                HasInsurance = false;
            }
            else
            {
                Console.WriteLine("Invalid insurance option.");
                return;
            }
            
            Console.Write("Enter Consultation Fee: ");
            ConsultationFee = decimal.Parse(Console.ReadLine());
            

            Console.Write("Enter Lab Charges: ");
            LabCharges = decimal.Parse(Console.ReadLine());
            

            Console.Write("Enter Medicine Charges: ");
            MedicineCharges = decimal.Parse(Console.ReadLine());

            if (ConsultationFee <= 0 || LabCharges < 0 || MedicineCharges < 0)
            {
                Console.WriteLine("Invalid fee values entered.");
                return;
            }



            Console.WriteLine("Bill created successfully.");

            GrossAmount = ConsultationFee + LabCharges + MedicineCharges;

            if(HasInsurance)
            {
                DiscountAmount = GrossAmount * 0.10M;
            }
            else
            {
                DiscountAmount = 0;
            }
            FinalPayable = GrossAmount - DiscountAmount;

            LastBill = this;
            HasLastBill = true;

            Console.WriteLine($"GrossAmount: {GrossAmount:F2}");
            Console.WriteLine($"DiscountAmount: {DiscountAmount:F2}");
            Console.WriteLine($"FinalPayable: {FinalPayable:F2}");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();



        }

        /// <summary>
        /// Displays the details of the most recently created bill in the console output.
        /// </summary>
        

        public void ViewLastBill()
        {
            Console.WriteLine("----------- Last Bill -----------");
            if (!HasLastBill || LastBill == null)
            {
                Console.WriteLine("No bill available. Please create a new bill first.");
                return;
            }
            Console.WriteLine($"BillId: {LastBill.BillId}");
            Console.WriteLine($"Patient: {LastBill.PatientName}");
            Console.Write($"Insured: ");
            if (LastBill.HasInsurance == true)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            Console.WriteLine($"ConsultationFee: {LastBill.ConsultationFee:F2}");
            Console.WriteLine($"Lab Charges: {LastBill.LabCharges:F2}");
            Console.WriteLine($"Medicine Charges: {LastBill.MedicineCharges:F2}");
            Console.WriteLine($"Gross Amount: {LastBill.GrossAmount:F2}");
            Console.WriteLine($"Discount Amount: {LastBill.DiscountAmount:F2}");
            Console.WriteLine($"Final Payable: {LastBill.FinalPayable:F2}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine();




        }

        /// <summary>
        /// Clears the record of the last bill and resets the related state.
        /// </summary>
        

        public void ClearBill()
        {
            LastBill = null;
            HasLastBill = false;
            Console.WriteLine("Last bill cleared.");
            Console.WriteLine();


        }
    }
}
