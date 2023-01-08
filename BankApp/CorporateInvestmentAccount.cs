using BankApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp
{
    public class CorporateInvestmentAccount : InvestmentAccount
    {
        public CorporateInvestmentAccount(int accountNumber, string owner, decimal balance)
            : base(accountNumber, owner, balance)
        {
        }
        public override InvestmentAccountType InvestmentAccountType => InvestmentAccountType.Corporate;
    }
}
