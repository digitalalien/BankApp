using BankApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp
{
    public class IndividualInvestmentAccount : InvestmentAccount
    {
        public IndividualInvestmentAccount(int accountNumber, string owner, decimal balance)
            : base(accountNumber, owner, balance)
        {
        }
        
        public decimal MaxWithdrawalAmount => 500;
        public override AccountType AccountType => AccountType.Investment;
        public override InvestmentAccountType InvestmentAccountType => InvestmentAccountType.Individual;

        public override bool Withdraw(decimal amount)
        {
            if (amount > MaxWithdrawalAmount)
            {
                return false;
            }
            return base.Withdraw(amount);
        }
    }
}
