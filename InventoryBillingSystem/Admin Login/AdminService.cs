using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace InventoryBillingSystem.Admin_Login
{
    internal class AdminService
    {
        private string adminUsername = "admin";
        private string adminPassword = "1234";

        public bool Login(string username, string password)
        {
            if (username == adminUsername && password == adminPassword)
            {
                return true;
            }
            return false;
        }
    }
}
