using InventoryBillingSystem.Billing;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryBillingSystem.Sales
{
    internal class SalesUI
    {
            private SalesService salesService =
                new SalesService();

        public void ShowSalesMenu()
        {
            while (true)
            {


                Console.WriteLine("---------- SALES MENU -----------");
                Console.WriteLine("1. View All Sales");
                Console.WriteLine("2. Back to Main Menu");

                Console.Write("Enter Choice: ");
                string choice = Console.ReadLine();




                if (choice == "1")
                {
                    ViewAllSales();
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Returning to Admin  Menu...");
                    return;

                }
                else
                {
                    Console.WriteLine("Invalid Choice!");

                }
            }
        }

            private void ViewAllSales()
            {
                List<BillingModel> bills =
                    salesService.GetAllSales();

                if (bills.Count == 0)
                {
                    Console.WriteLine("\nNo Sales Records Found!");
                    return;
                }

                Console.WriteLine("-------- ALL SALES DETAILS --------------------");

                foreach (BillingModel bill in bills)
                {
                    Console.WriteLine("Bill ID: " + bill.BillId);
                    Console.WriteLine("Customer Name: " + bill.CustomerName);
                    Console.WriteLine("Customer Mobile: " + bill.CustomerMobile);
                    Console.WriteLine("Payment Type: " + bill.PaymentType);

                    Console.WriteLine("Product Details:");

                    Console.WriteLine(
                        "Product | Quantity | Price | Total");

                    decimal subtotal = 0;

                    for (int i = 0; i < bill.ProductNames.Count; i++)
                    {
                        Console.WriteLine(
                            bill.ProductNames[i] + " | " +
                            bill.ProductQuantities[i] + " | " +
                            bill.ProductPrices[i] + " | " +
                            bill.ProductTotals[i]);

                        subtotal += bill.ProductTotals[i];
                    }

                    Console.WriteLine("\nSubtotal: " + subtotal);
                    Console.WriteLine("Discount: " + bill.Discount + "%");
                    Console.WriteLine(
                        "Discount Amount: " + bill.DiscountAmount);
                    Console.WriteLine("Final Total: " + bill.FinalTotal);

                    Console.WriteLine("---------------------------------------");
                }

                Console.WriteLine("----------- TOTAL SALES ---------------");
                Console.WriteLine("Total Bills: " + bills.Count);
                Console.WriteLine(
                    "Total Sales: " + salesService.GetTotalSales());

                Console.WriteLine("-------------------------------------");
            }
        }
    }
