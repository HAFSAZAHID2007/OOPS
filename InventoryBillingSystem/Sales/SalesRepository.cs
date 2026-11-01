using InventoryBillingSystem.Billing;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryBillingSystem.Sales
{
    internal class SalesRepository
    {
        private BillingRepository billingRepository =
            new BillingRepository();

        public List<BillingModel> GetAllSales()
        {
            return billingRepository.LoadBills();
        }
    }
}
