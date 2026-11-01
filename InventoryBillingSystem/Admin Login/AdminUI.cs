using InventoryBillingSystem.Product;
using InventoryBillingSystem.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryBillingSystem.Admin_Login
{
    internal class AdminUI
    {
        private SalesUI salesUI = new SalesUI();
        private ProductUI productUI = new ProductUI();
        private AdminService adminService =
            new AdminService();

        public void ShowLogin()
        {
            Console.WriteLine("------- ADMIN LOGIN --------");



            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            bool result = adminService.Login(username, password);

            if (!result)
            {
                Console.WriteLine("Invalid Username or Password!");
                return;
            }


            Console.WriteLine("Admin Login Successful!");
            while (true)
            {
                Console.WriteLine("---------- ADMIN MENU ----------");
                Console.WriteLine("1. Products");
                Console.WriteLine("2. Sales");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter Choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    productUI.ShowProductMenu();

                }
                else if (choice == "2")
                {
                    salesUI.ShowSalesMenu();
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Admin Logged OUt!");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice ");
                }


            }



        }

    }
}