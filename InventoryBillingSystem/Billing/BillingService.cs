using InventoryBillingSystem.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryBillingSystem.Billing
{
    internal class BillingService
    {
        private List<BillingModel> bills = new List<BillingModel>();
        private BillingRepository repository = new BillingRepository();
        private ProductService productService = new ProductService();

        public BillingService()
        {
            bills = repository.LoadBills();
            productService.LoadProducts();
        }

        // Create Bill
        public BillingModel CreateBill(
            string customerName,
            string customerMobile,
            string paymentType)
        {
            BillingModel bill = new BillingModel();

            bill.BillId = bills.Count + 1;
            bill.CustomerName = customerName;
            bill.CustomerMobile = customerMobile;
            bill.PaymentType = paymentType;

            bills.Add(bill);

            return bill;
        }

        // Add Item to Bill
        public bool AddItemToBill(
            BillingModel bill,
            string productName,
            int quantity)
        {
            if (quantity <= 0)
            {
                return false;
            }

            ProductModel selectedProduct = null;

            foreach (ProductModel product in productService.ViewProducts())
            {
                if (product.ProductName == productName)
                {
                    selectedProduct = product;
                    break;
                }
            }

            if (selectedProduct == null)
            {
                return false;
            }

            if (selectedProduct.ProductQty < quantity)
            {
                return false;
            }

            int price = selectedProduct.ProductPrice;

            bool updated = productService.UpdateStock(
                productName, -quantity);

            if (updated == false)
            {
                return false;
            }

            bill.ProductNames.Add(selectedProduct.ProductName);
            bill.ProductQuantities.Add(quantity);
            bill.ProductPrices.Add(price);
            bill.ProductTotals.Add(quantity * price);

            return true;
        }

        // Remove Item from Bill
        public bool RemoveItemFromBill(BillingModel bill, int index)
        {
            if (index < 0 || index >= bill.ProductNames.Count)
            {
                return false;
            }

            string productName = bill.ProductNames[index];
            int quantity = bill.ProductQuantities[index];

            // Restore stock
            bool updated = productService.UpdateStock(
                productName, quantity);

            if (updated == false)
            {
                return false;
            }

            bill.ProductNames.RemoveAt(index);
            bill.ProductQuantities.RemoveAt(index);
            bill.ProductPrices.RemoveAt(index);
            bill.ProductTotals.RemoveAt(index);

            return true;
        }

        // Calculate Discount
        public bool CalculateDiscount(BillingModel bill, decimal discount)
        {
            if (discount < 0 || discount > 100)
            {
                return false;
            }

            decimal subtotal = 0;

            foreach (int total in bill.ProductTotals)
            {
                subtotal += total;
            }

            bill.Discount = discount;
            bill.DiscountAmount = subtotal * discount / 100;
            bill.FinalTotal = subtotal - bill.DiscountAmount;

            return true;
        }

        // Save Bills
        public void SaveBills()
        {
            repository.SaveBills(bills);
        }

        public List<BillingModel> GetAllBills()
        {
            return bills;
        }

    }
}
