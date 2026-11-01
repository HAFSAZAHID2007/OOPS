using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryBillingSystem.Admin_Login
{
    internal class AdminModel
    {
        private string username;
        private string password;
        public string Username
        {
            get { return username; }
            set { username = value; }

        }
        public string Password
        {
            get { return password; }
            set { password = value; }

        }
    }
}
