using System;
using System.Collections.Generic;

namespace InventoryBillingSystem.Product
{
    internal class ProductService
    {
        private List<ProductModel> products = new List<ProductModel>();
        private ProductRepository repository = new ProductRepository();

        public void LoadProducts()
        {
            products = repository.LoadProducts();
        }

        public void AddProduct(ProductModel product)
        {
            products.Add(product);
            repository.SaveProducts(product);
        }

        public List<ProductModel> ViewProducts()
        {
            return products;
        }

        // Search product
        public ProductModel SearchProduct(List<ProductModel> products, string productName)
        {
            foreach (ProductModel p in products)
            {
                if (p.ProductName == productName)
                {
                    return p;
                }
            }

            return null;
        }

        // Update product price and quantity
        public bool UpdateProduct(string productName, int newPrice, int newQty)
        {
            ProductModel product = SearchProduct(products, productName);

            if (product == null)
            {
                return false;
            }

            if (newPrice <= 0 || newQty <= 0)
            {
                return false;
            }

            product.ProductPrice = newPrice;
            product.ProductQty = newQty;

            repository.SaveAllProducts(products);

            return true;
        }

        // Update stock
        public bool UpdateStock(string productName, int quantityChange)
        {
            ProductModel product = SearchProduct(products, productName);

            if (product == null)
            {
                return false;
            }

            int newQty = product.ProductQty + quantityChange;

            if (newQty < 0)
            {
                return false;
            }

            product.ProductQty = newQty;
            repository.SaveAllProducts(products);

            return true;
        }

        // Delete product
        public bool DeleteProduct(string productName)
        {
            ProductModel product = SearchProduct(products, productName);

            if (product == null)
            {
                return false;
            }

            products.Remove(product);
            repository.SaveAllProducts(products);

            return true;
        }
    }
}