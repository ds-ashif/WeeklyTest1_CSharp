using System;

namespace QuickMartTraders
{
    /// <summary>
    /// Represents a sales transaction within the QuickMart Traders system.
    /// This class is responsible for capturing transaction details,
    /// calculating profit or loss, and storing the most recent transaction.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="SaleTransaction"/> class supports basic console-based
    /// transaction input and financial analysis.
    /// </para>
    /// <para>
    /// The most recently processed transaction is stored statically and can
    /// be viewed or recalculated at any time during application execution.
    /// </para>
    /// </remarks>
    
    public class SaleTransaction
    {

        #region Static Members
        /// <summary>
        /// Stores the most recent sale transaction processed by the system.
        /// </summary>
        /// <remarks>
        /// This value will be <c>null</c> if no transaction has been created yet.
        /// </remarks>
       
        public static SaleTransaction? LastTransaction;
        /// <summary>
        /// Indicates whether a valid last transaction exists.
        /// </summary>
        public static bool HasLastTransaction = false;
        #endregion


        #region Transaction Properties

        /// <summary>
        /// Gets or sets the invoice number associated with the transaction.
        /// </summary>
        public string? InvoiceNo { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer involved in the transaction.
        /// </summary>
        public string? CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the item sold.
        /// </summary>

        public string? ItemName { get; set; }

        /// <summary>
        /// Gets or sets the quantity of items sold.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the total purchase cost of the items.
        /// </summary>
        public decimal PurchaseAmount { get; set; }

        /// <summary>
        /// Gets or sets the total selling amount of the items.
        /// </summary>
        public decimal SellingAmount { get; set; }

        /// <summary>
        /// Gets the profit or loss status of the transaction
        /// (PROFIT, LOSS, or BREAK-EVEN).
        /// </summary>
        public string ProfitOrLossStatus { get; set; }

        /// <summary>
        /// Gets the absolute profit or loss amount.
        /// </summary>
        public decimal ProfitOrLossAmount { get; set; }

        /// <summary>
        /// Gets the profit margin percentage based on purchase amount.
        /// </summary>
        public decimal ProfitMarginPercent { get; set; }
        #endregion


        #region Transaction Creation

        /// <summary>
        /// Captures transaction details from the console, validates input,
        /// calculates profit or loss, and stores the transaction.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method performs input validation and terminates early if
        /// invalid data is detected.
        /// </para>
        /// <para>
        /// On successful completion, the transaction is stored as the
        /// most recent transaction.
        /// </para>
        /// </remarks>


        public void CreateTransaction()
        {
            Console.Write("Enter Invoice No: ");
            InvoiceNo = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(InvoiceNo))
            {
                Console.WriteLine("Invoice No cannot be empty.");
                return;
            }

            Console.Write("Enter Customer Name: ");
            CustomerName = Console.ReadLine();

            Console.Write("Enter Item Name: ");
            ItemName = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            Quantity = int.Parse(Console.ReadLine());
            if (Quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than zero.");
                return;
            }

            Console.Write("Enter Purchase Amount (total): ");
            PurchaseAmount = decimal.Parse(Console.ReadLine());
            if (PurchaseAmount <= 0)
            {
                Console.WriteLine("Purchase Amount must be greater than zero.");
                return;
            }

            Console.Write("Enter Selling Amount (total): ");
            SellingAmount = decimal.Parse(Console.ReadLine());
            if (SellingAmount < 0)
            {
                Console.WriteLine("Selling Amount cannot be negative.");
                return;
            }

            ///<summary>
            /// Calling this function to calculate
            /// </summary>
            CalculateProfitLoss();

            LastTransaction = this;
            HasLastTransaction = true;

            Console.WriteLine("\nTransaction saved successfully.");
            PrintCalculation();
            Console.WriteLine("------------------------------------------------------");
        }
        #endregion

        #region Financial Calculations


        /// <summary>
        /// Calculates the profit or loss amount, status,
        /// and profit margin percentage for the transaction.
        /// </summary>
        /// <remarks>
        /// Profit margin is calculated using the formula:
        /// <c>(ProfitOrLossAmount / PurchaseAmount) × 100</c>.
        /// </remarks>
        
        public void CalculateProfitLoss()
        {
            if (SellingAmount > PurchaseAmount)
            {
                ProfitOrLossStatus = "PROFIT";
                ProfitOrLossAmount = SellingAmount - PurchaseAmount;
            }
            else if (SellingAmount < PurchaseAmount)
            {
                ProfitOrLossStatus = "LOSS";
                ProfitOrLossAmount = PurchaseAmount - SellingAmount;
            }
            else
            {
                ProfitOrLossStatus = "BREAK-EVEN";
                ProfitOrLossAmount = 0;
            }

            ProfitMarginPercent = (ProfitOrLossAmount / PurchaseAmount) * 100;
        }
        #endregion

        #region Transaction Viewing

        /// <summary>
        /// Displays the details of the most recent transaction.
        /// </summary>
        /// <remarks>
        /// If no transaction exists, an informative message is displayed.
        /// </remarks>

        public void ViewLastTransaction()
        {
            if (!HasLastTransaction || LastTransaction == null)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            Console.WriteLine("\n-------------- Last Transaction --------------");
            Console.WriteLine($"InvoiceNo: {LastTransaction.InvoiceNo}");
            Console.WriteLine($"Customer: {LastTransaction.CustomerName}");
            Console.WriteLine($"Item: {LastTransaction.ItemName}");
            Console.WriteLine($"Quantity: {LastTransaction.Quantity}");
            Console.WriteLine($"Purchase Amount: {LastTransaction.PurchaseAmount:F2}");
            Console.WriteLine($"Selling Amount: {LastTransaction.SellingAmount:F2}");
            Console.WriteLine($"Status: {LastTransaction.ProfitOrLossStatus}");
            Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount:F2}");
            Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent:F2}");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("------------------------------------------------------");
        }

        /// <summary>
        /// Recalculates and displays profit or loss information
        /// for the most recent transaction.
        /// </summary>
        public void RecalculateProfitLoss()
        {
            if (!HasLastTransaction || LastTransaction == null)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            LastTransaction.CalculateProfitLoss();
            LastTransaction.PrintCalculation();
            Console.WriteLine("------------------------------------------------------");
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Prints calculated profit or loss details to the console.
        /// </summary>

        private void PrintCalculation()
        {   
            Console.WriteLine($"Status: {ProfitOrLossStatus}");
            Console.WriteLine($"Profit/Loss Amount: {ProfitOrLossAmount:F2}");
            Console.WriteLine($"Profit Margin (%): {ProfitMarginPercent:F2}");
        }
        #endregion
    }
}
