using System;
using System.Collections.Generic;
using System.Text;
using InventoryBillingSystem.Product;
namespace InventoryBillingSystem.Billing
{
    public class BillingUI
    {

        private BillingService billingService = new BillingService();
        private BillingModel currentBill = null;

        public void ShowBillingMenu()
        {


            while (true)
            {
                Console.WriteLine("---------- BILLING MENU ----------");
                Console.WriteLine("1. Create Bill");
                Console.WriteLine("2. Add Item to Bill");
                Console.WriteLine("3. Remove Item from Bill");
                Console.WriteLine("4. Add Discount");
                Console.WriteLine("5. Print Receipt");
                Console.WriteLine("6. Logout");

                Console.Write("Enter Choice: ");
                string choice = Console.ReadLine();


                if (choice == "1")
                {
                    CreateBill();

                }
                else if (choice == "2")
                {
                    AddItem();

                }
                else if (choice == "3") { RemoveItem(); }
                else if (choice == "4") { AddDiscount(); }
                else if (choice == "5") { PrintReceipt(); }
                else if (choice == "6")
                {
                    Console.WriteLine("Staff Logged Out!");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid Choice!");
                }
            }
        }

        // Create Bill
        private void CreateBill()
        {
            Console.Write("\nCustomer Name: ");
            string name = Console.ReadLine();

            Console.Write("Customer Mobile: ");
            string mobile = Console.ReadLine();



            Console.Write("Payment Type: ");

            string paymentType = Console.ReadLine();



            currentBill = billingService.CreateBill(
                name, mobile, paymentType);

            Console.WriteLine("Bill Created Successfully!");
            Console.WriteLine("Bill ID: " + currentBill.BillId);
        }

        // Add Item
        private void AddItem()
        {
            if (currentBill == null)
            {
                Console.WriteLine("Please Create a Bill First!");
                return;
            }

            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Quantity: ");

            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.WriteLine("Invalid Quantity!");
                return;
            }

            billingService.AddItemToBill(
                currentBill, productName, quantity);
        }

        // Remove Item
        private void RemoveItem()
        {
            if (currentBill == null)
            {
                Console.WriteLine("Please Create a Bill First!");
                return;
            }

            if (currentBill.ProductNames.Count == 0)
            {
                Console.WriteLine("No Items in Bill!");
                return;
            }

            PrintProducts();

            Console.Write("Enter Item Number to Remove: ");

            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Invalid Item Number!");
                return;
            }

            billingService.RemoveItemFromBill(
                currentBill, number - 1);
        }

        // Add Discount
        private void AddDiscount()
        {
            if (currentBill == null)
            {
                Console.WriteLine("Please Create a Bill First!");
                return;
            }

            Console.Write("Enter Discount Percentage: ");

            if (!decimal.TryParse(Console.ReadLine(), out decimal discount))
            {
                Console.WriteLine("Invalid Discount!");
                return;
            }

            billingService.CalculateDiscount(
                currentBill, discount);
        }

        // Display Products
        private void PrintProducts()
        {
            Console.WriteLine("--------- BILL ITEMS ----------");

            for (int i = 0; i < currentBill.ProductNames.Count; i++)
            {
                Console.WriteLine((i + 1) + "." + currentBill.ProductNames[i] + " Qty: " + currentBill.ProductQuantities[i] + " Price: " + currentBill.ProductPrices[i] + "Total: " + currentBill.ProductTotals[i]);
            }
        }

        // Print Receipt
        private void PrintReceipt()
        {
            if (currentBill == null)
            {
                Console.WriteLine("Please Create a Bill First!");
                return;
            }

            if (currentBill.ProductNames.Count == 0)
            {
                Console.WriteLine("No Items in Bill!");
                return;
            }

            billingService.CalculateDiscount(
                currentBill, currentBill.Discount);

            decimal subtotal = 0;

            foreach (int total in currentBill.ProductTotals)
            {
                subtotal += total;
            }

            Console.WriteLine("--------- RECEIPT ----------");
            Console.WriteLine("Bill ID: " + currentBill.BillId);
            Console.WriteLine("Customer: " + currentBill.CustomerName);
            Console.WriteLine("Mobile: " + currentBill.CustomerMobile);
            Console.WriteLine("Payment: " + currentBill.PaymentType);

            PrintProducts();

            Console.WriteLine("-----------------------------");
            Console.WriteLine("Subtotal: " + subtotal);
            Console.WriteLine("Discount: " + currentBill.Discount + "%");
            Console.WriteLine("Discount Amount: " + currentBill.DiscountAmount);
            Console.WriteLine("Final Total: " + currentBill.FinalTotal);
           

            billingService.SaveBills();

            Console.WriteLine("Bill Saved Successfully!");
        }
    }

}
