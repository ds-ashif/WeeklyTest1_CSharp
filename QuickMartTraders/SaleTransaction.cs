using System;

namespace QuickMartTraders
{
    public class SaleTransaction
    {
        /// <summary>
        /// Represents the most recent sale transaction processed by the system, or null if no transactions have
        /// occurred.
        /// </summary>
        public static SaleTransaction? LastTransaction;
        public static bool HasLastTransaction = false;


        /// <summary>
        ///  Properties
        /// </summary>
        public string? InvoiceNo { get; set; }
        public string? CustomerName { get; set; }
        public string? ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal SellingAmount { get; set; }

        public string ProfitOrLossStatus { get; set; }
        public decimal ProfitOrLossAmount { get; set; }
        public decimal ProfitMarginPercent { get; set; }

        /// <summary>
        /// creating the transaction
        /// </summary>
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

        /// <summary>
        /// Calculates profit or loss amount, status,
        /// and profit margin percentage.
        /// </summary>
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

        /// <summary>
        /// Displays the last stored transaction details.
        /// </summary>
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
        /// Recalculates and prints profit/loss details
        /// for the last transaction.
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

        // ===== HELPER PRINT METHOD =====
        private void PrintCalculation()
        {
            Console.WriteLine($"Status: {ProfitOrLossStatus}");
            Console.WriteLine($"Profit/Loss Amount: {ProfitOrLossAmount:F2}");
            Console.WriteLine($"Profit Margin (%): {ProfitMarginPercent:F2}");
        }
    }
}
