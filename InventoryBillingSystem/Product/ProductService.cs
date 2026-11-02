using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

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
       //NameSearch
        public List<ProductModel> NameSearch(char n)
        {
            List < ProductModel> result = new List<ProductModel>();
            foreach(ProductModel product in products)
            {
                for( int i = 0;int < product.ProductName.Length;i++)
                    if (product.ProductName[i] == n)
                {
                         result.Add(product);
                }
            }
            return result;

        }
        //Numeric Range
        public List<ProductModel> NumericRange(int  max, int  min) 
        { 
            List <ProductModel> range = new List<ProductModel>();
            foreach (ProductModel product in products)
            {
                if(product.ProductPrice > min &&  product.ProductPrice < max )
                {
                    range.Add(product);
                }
                return range;
            }
        }
        public  List<ProductModel> CategoryMatch(string c ) {
            List<ProductModel> CtgFilter = new List<ProductModel>();
            
            foreach (ProductModel product in products)
            {
                for(int i = 0; i < product.ProductCategory.Length; i++) { }
               if(product.ProductCategory[i] == c)
                {
                    CtgFilter.Add(product);
                    
                }
            }
           
            
        }

         




    }
}