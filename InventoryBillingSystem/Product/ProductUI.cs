using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryBillingSystem.Product
{
    public class ProductUI
    {

        private ProductService service = new ProductService();

        // Product Menu
       
public void ShowProductMenu()
        {
            

            while (true) {

                Console.WriteLine("---------- PRODUCT MENU -------");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Update Product");
                Console.WriteLine("5. Delete Product");
                Console.WriteLine("6. Filter Product");


                Console.WriteLine("7. Back to Main Menu");

                Console.Write("Enter Choice: ");
            string     choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddProductUI();
                }
                else if (choice == "2")
                {
                    ViewProductsUI();
                }
                else if (choice == "3")
                {
                    SearchProductUI();
                }
                else if (choice == "4")
                {
                    UpdateProductUI();
                }
                else if (choice == "5")
                {
                    DeleteProductUI();
                }
                else if (choice == "6")
                {
                   //filterfunction
                   FilterProductUI();
                }
                else if (choice == "7")
                {
                    Console.WriteLine("Returning to Admin Menu...");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid Choice!");
                }
            }
             }
    
        // Add Product UI
        private void AddProductUI()
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            int price = int.Parse(Console.ReadLine());

            Console.Write("Enter Product Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            Console.Write("Enter Product Category: ");
            string ctg = Console.ReadLine();


            ProductModel product = new ProductModel(name, price, qty , ctg);

            service.AddProduct(product);

            Console.WriteLine("Product Added Successfully!");
        }

        // View Products UI
        private void ViewProductsUI()
        {
            List<ProductModel> products = service.ViewProducts();

            foreach (ProductModel product in products)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Name: " + product.ProductName);
                Console.WriteLine("Price: " + product.ProductPrice);
                Console.WriteLine("Quantity: " + product.ProductQty);
                Console.WriteLine("Category: " + product.ProductCategory);

            }
        }

        //SearchOption Product UI
        private void SearchProductUI()
        {
            Console.Write("Enter Product Name to Search: ");
            string name = Console.ReadLine();

            ProductModel product = service.SearchProduct(
                service.ViewProducts(), name);

            if (product != null)
            {
                Console.WriteLine("Product Found!");
                Console.WriteLine("Name: " + product.ProductName);
                Console.WriteLine("Price: " + product.ProductPrice);
                Console.WriteLine("Quantity: " + product.ProductQty);
                Console.WriteLine("Category: " + product.ProductCategory);

            }
            else
            {
                Console.WriteLine("Product Not Found!");
            }
        }

        // Update Product UI
        private void UpdateProductUI()
        {
            Console.Write("Enter Product Name to Update: ");
            string name = Console.ReadLine();

            ProductModel product = service.SearchProduct(
                service.ViewProducts(), name);

            if (product == null)
            {
                Console.WriteLine("Product not found!");
                return;
            }

            Console.Write("Enter New Price: ");
            int newPrice = int.Parse(Console.ReadLine());

            while (newPrice <= 0)
            {
                Console.Write("Invalid price! Enter again: ");
                newPrice = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter New Quantity: ");
            int newQty = int.Parse(Console.ReadLine());

            while (newQty <= 0)
            {
                Console.Write("Invalid quantity! Enter again: ");
                newQty = int.Parse(Console.ReadLine());
            }

            bool result = service.UpdateProduct(name, newPrice, newQty);

            if (result == true)
            {
                Console.WriteLine("Product Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Product Update Failed!");
            }
        }

        // Delete Product UI
        private void DeleteProductUI()
        {
            Console.Write("Enter Product Name to Delete: ");
            string name = Console.ReadLine();

            bool result = service.DeleteProduct(name);

            if (result == true)
            {
                Console.WriteLine("Product Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Product Not Found!");
            }
        }
         //FilterFunction
        private void FilterProductUI()
        {
            Console.WriteLine("Enter the product character  you want to search");
            char character = char.Parse (Console.ReadLine());
            
            List<ProductModel> result = service.NameSearch(character);
            foreach (ProductModel p in result)
            {
                Console.WriteLine(p.ProductName);
            }

            Console.WriteLine("Enter the Max Range of Price");

            int MaxRange = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Min Range of Price");
            int MinRange = int.Parse(Console.ReadLine());
            List<ProductModel> range = service.NumericRange(MaxRange, MinRange);
            foreach (ProductModel p in range)
            { 
                Console.WriteLine(p.ProductName);
                Console.WriteLine(p.ProductPrice);
              
            }

            Console.WriteLine("Enter Category ");
            string C = Console.ReadLine();
            List<ProductModel> CtgFilter = service.CategoryMatch(C);
            foreach (ProductModel p in CtgFilter)
            {
                Console.WriteLine(p.ProductName);
                Console.WriteLine(p.ProductCategory);
            }

        }
       
    }
}
    
