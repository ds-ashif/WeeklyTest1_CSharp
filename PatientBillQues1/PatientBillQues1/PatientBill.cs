using System;
using System.Collections.Generic;
using System.Text;

namespace PatientBillQues1
{
    /// <summary>
    /// Represents a patient's billing record in a medical billing system.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class is responsible for capturing patient billing details,
    /// calculating gross amount, applying insurance-based discounts,
    /// and determining the final payable amount.
    /// </para>
    /// <para>
    /// The most recently created bill is stored statically and can be
    /// viewed or cleared during the application's execution.
    /// </para>
    /// </remarks>
    


    public class PatientBill
    {
        #region Static Members

        /// <summary>
        /// <summary>
        /// Stores the most recently generated patient bill.
        /// </summary>
        /// <remarks>
        /// This value will be <c>null</c> if no bill has been created.
        /// </remarks>
        public static PatientBill? LastBill;

        /// <summary>
        /// Indicates whether a valid last bill exists.
        /// </summary>
        public static bool HasLastBill = false;
        #endregion


        #region Bill Properties

        /// <summary>
        /// Gets or sets the unique identifier for the bill.
        /// </summary>
        public string? BillId { get; set; }

        /// <summary>
        /// Gets or sets the name of the patient.
        /// </summary>
        public string? PatientName{get; set;}

        /// <summary>
        /// Gets or sets a value indicating whether the patient has insurance coverage.
        /// </summary>
        public bool HasInsurance { get; set; }

        /// <summary>
        /// Gets or sets the consultation fee charged to the patient.
        /// </summary>
        public decimal ConsultationFee { get; set; }

        /// <summary>
        /// Gets or sets the laboratory charges incurred by the patient.
        /// </summary>
        public decimal LabCharges { get; set; }

        /// <summary>
        /// Gets or sets the medicine charges incurred by the patient.
        /// </summary>
        public decimal MedicineCharges { get; set; }

        /// <summary>
        /// Gets or sets the total amount before discounts.
        /// </summary>
        public decimal GrossAmount { get; set; }

        /// <summary>
        /// Gets or sets the discount amount applied to the bill.
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// Gets or sets the final payable amount after discounts.
        /// </summary>
        public decimal FinalPayable { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientBill"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor does not initialize any values explicitly.
        /// All values are populated through user input.
        /// </remarks>
        



        public PatientBill()
        {
            
        }
        #endregion

        #region Bill Creation

        /// <summary>
        /// Prompts the user to enter patient billing details,
        /// performs validation, calculates billing amounts,
        /// and stores the bill as the most recent record.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A discount of 10% is applied if the patient has insurance.
        /// </para>
        /// <para>
        /// If invalid input is detected, the method terminates early
        /// without creating a bill.
        /// </para>
        /// </remarks>
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
        #endregion

        #region Bill Viewing

        /// <summary>
        /// Displays the details of the most recently created bill.
        /// </summary>
        /// <remarks>
        /// If no bill exists, an informational message is displayed.
        /// </remarks>
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

        #endregion

        #region Bill Maintenance

        /// <summary>
        /// Clears the record of the most recently created bill.
        /// </summary>
        /// <remarks>
        /// After calling this method, no bill will be available
        /// for viewing until a new bill is created.
        /// </remarks>
        public void ClearBill()
        {
            LastBill = null;
            HasLastBill = false;
            Console.WriteLine("Last bill cleared.");
            Console.WriteLine();
        }
        #endregion

    }
}
