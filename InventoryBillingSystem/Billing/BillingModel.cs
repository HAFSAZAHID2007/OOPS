using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryBillingSystem.Billing
{
    public class BillingModel
    {
        private int billId;
        private string customerName;
        private string customerMobile;
        private string paymentType;

        private List<string> productNames = new List<string>();
        private List<int> productQuantities = new List<int>();
        private List<int> productPrices = new List<int>();
        private List<int> productTotals = new List<int>();

        private decimal discount;
        private decimal discountAmount;

        private decimal finalTotal;
        public int BillId
        {
            get { return billId; }
            set { billId = value; }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public string CustomerMobile
        {
            get { return customerMobile; }
            set { customerMobile = value; }
        }

        public string PaymentType
        {
            get { return paymentType; }
            set { paymentType = value; }
        }

        public List<string> ProductNames
        {
            get { return productNames; }
            set { productNames = value; }
        }

        public List<int> ProductQuantities
        {
            get { return productQuantities; }
            set { productQuantities = value; }
        }

        public List<int> ProductPrices
        {
            get { return productPrices; }
            set { productPrices = value; }
        }

        public List<int> ProductTotals
        {
            get { return productTotals; }
            set { productTotals = value; }
        }

        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public decimal DiscountAmount
        {
            get { return discountAmount; }
            set { discountAmount = value; }
        }

        public decimal FinalTotal
        {
            get { return finalTotal; }
            set { finalTotal = value; }
        }


    }
}
