using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace InventoryBillingSystem.Product
{
    public class ProductRepository
    {
        private readonly string filePath = "products.txt";

        public void SaveProducts(ProductModel product)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(product.ProductName + "," + product.ProductPrice + "," + product.ProductQty);
            }


        }

        public List<ProductModel> LoadProducts()
        {
            List<ProductModel> products = new List<ProductModel>();
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        ProductModel product
                             = new ProductModel(
                                 data[0], int.Parse(data[1]), int.Parse(data[2]));
                        products.Add(product);

                    }
                }

            }
            return products;
        }
        public void SaveAllProducts(List<ProductModel> products)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (ProductModel product in products) 
                {
                    writer.WriteLine(product.ProductName + "," + product.ProductPrice + "," + product.ProductQty);
                }

            }
        }
    }
}