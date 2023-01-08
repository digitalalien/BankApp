using BankApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(int accountNumber, string owner, decimal balance)
            : base(accountNumber, owner, balance)
        {
        }
        public override AccountType AccountType => AccountType.Checking;
    }
}
