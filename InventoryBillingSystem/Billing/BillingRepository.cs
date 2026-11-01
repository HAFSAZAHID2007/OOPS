using InventoryBillingSystem.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryBillingSystem.Billing
{
    public class BillingRepository
    {
        private string filePath = "sales.txt";

        public void SaveBills(List<BillingModel> bills)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (BillingModel bill in bills)
                {
                    writer.WriteLine(bill.BillId);
                    writer.WriteLine(bill.CustomerName);
                    writer.WriteLine(bill.CustomerMobile);
                    writer.WriteLine(bill.PaymentType);

                    writer.WriteLine(bill.ProductNames.Count);

                    for (int i = 0; i < bill.ProductNames.Count; i++)
                    {
                        writer.WriteLine(bill.ProductNames[i]);
                        writer.WriteLine(bill.ProductQuantities[i]);
                        writer.WriteLine(bill.ProductPrices[i]);
                        writer.WriteLine(bill.ProductTotals[i]);
                    }

                    writer.WriteLine(bill.Discount);
                    writer.WriteLine(bill.DiscountAmount);
                    writer.WriteLine(bill.FinalTotal);
                }
            }
        }

        public List<BillingModel> LoadBills()
        {
            List<BillingModel> bills = new List<BillingModel>();

            if (!File.Exists(filePath))
                return bills;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    BillingModel bill = new BillingModel();

                    bill.BillId = int.Parse(line);
                    bill.CustomerName = reader.ReadLine();
                    bill.CustomerMobile = reader.ReadLine();
                    bill.PaymentType = reader.ReadLine();

                    int count = int.Parse(reader.ReadLine());

                    for (int i = 0; i < count; i++)
                    {
                        bill.ProductNames.Add(reader.ReadLine());
                        bill.ProductQuantities.Add(int.Parse(reader.ReadLine()));
                        bill.ProductPrices.Add(int.Parse(reader.ReadLine()));
                        bill.ProductTotals.Add(int.Parse(reader.ReadLine()));
                    }

                    bill.Discount = decimal.Parse(reader.ReadLine());
                    bill.DiscountAmount = decimal.Parse(reader.ReadLine());
                    bill.FinalTotal = decimal.Parse(reader.ReadLine());

                    bills.Add(bill);
                }
            }

            return bills;
        }


    }
}
