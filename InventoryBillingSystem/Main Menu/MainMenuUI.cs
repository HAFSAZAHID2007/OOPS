using InventoryBillingSystem.Product;
using System;
using System.Collections.Generic;
using System.Text;
using InventoryBillingSystem.Product;
using InventoryBillingSystem.Billing;
using InventoryBillingSystem.Admin_Login;

using InventoryBillingSystem.Sales;
//using InventoryBillingSystem.Admin_Login;

namespace InventoryBillingSystem.Main_Menu
{
    public class MainMenuUI
    {
        private AdminUI adminUI = new AdminUI();


        private BillingUI billingUI = new BillingUI();


        public void ShowMainMenu()
        {
            while (true)
            {
                int choice;



                Console.WriteLine("------ MAIN MENU ---------");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Staff");


                Console.WriteLine("3. Exit");

                Console.Write("Enter Choice: ");
                choice = int.Parse(Console.ReadLine());


                if (choice == 1)
                {
                    adminUI.ShowLogin();



                }
                else if (choice == 2)
                {
                    billingUI.ShowBillingMenu();
                }

                else if (choice == 3)
                {
                    Console.WriteLine("Thank You for Using Our System!");
                    return;

                }
                else
                {
                    Console.WriteLine("Invalid Choice!");

                }
            }
        }
    }
}
    






