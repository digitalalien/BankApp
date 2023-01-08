using BankApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace BankApp
{
    public abstract class Account
    {
        public int AccountNumber { get; private set; }
        public string Owner { get; private set; }
        public decimal Balance { get; private set; }
        public abstract AccountType AccountType { get; }

        public Account(int AccountNumber, string Owner, decimal Balance)
        {
            this.AccountNumber = AccountNumber;
            this.Owner = Owner;
            this.Balance = Balance;
        }
        public virtual bool Withdraw(decimal amount)
        {
            if (amount <= 0 || Balance - amount < 0)
            {
                return false;
            }
            Balance -= amount;
            return true;
        }

        public virtual bool Deposit(decimal amount)
        {
            if(amount <= 0)
            {
                return false;
            }
            
            Balance += amount;
            return true;
        }

        public virtual bool Transfer(Account destination, decimal amount)
        {
            if (Withdraw(amount))
            {
                return destination.Deposit(amount);
            }
            return false;
        }
    }
}
