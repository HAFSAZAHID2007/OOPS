using InventoryBillingSystem.Billing;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryBillingSystem.Sales
{
    internal class SalesService
    {
       
            private SalesRepository repository =
                new SalesRepository();

            public List<BillingModel> GetAllSales()
            {
                return repository.GetAllSales();
            }

            public decimal GetTotalSales()
            {
                decimal totalSales = 0;

                List<BillingModel> bills = GetAllSales();

                foreach (BillingModel bill in bills)
                {
                    totalSales += bill.FinalTotal;
                }

                return totalSales;
            }
        }
    }