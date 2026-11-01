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

        public ProductModel(string name, int price, int qty) { 
            ProductName = name;
            ProductPrice = price;
            ProductQty = qty;
        
        }

    }
}
