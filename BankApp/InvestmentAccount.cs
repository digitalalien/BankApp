using BankApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp
{
    public abstract class InvestmentAccount: Account
    {
        public InvestmentAccount(int accountNumber, string owner, decimal balance)
            : base(accountNumber, owner, balance)
        {
        }
        public override AccountType AccountType => AccountType.Investment;
        public abstract InvestmentAccountType InvestmentAccountType { get; }
    }
}
