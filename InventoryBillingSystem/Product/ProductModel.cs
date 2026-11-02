using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryBillingSystem.Product
{
    public class ProductModel
    {
        private string productName;
        private int productPrice;
        private int productQty;
        private string productCategory;

        public string ProductCategory
        {
            get { return productCategory; }
            set { productCategory = value; }
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }

        }
        public int ProductPrice
        {
            get
            {
                return productPrice;
            }
            set
            {
                productPrice = value;
            }
        }
        public int ProductQty
        {
            get { return productQty; }

            set { productQty = value; }
        }

        public ProductModel(string name, int price, int qty,string CTG) { 
            ProductName = name;
            ProductPrice = price;
            ProductQty = qty;
            ProductCategory = CTG;
        
        }

    }
}
