using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp
{
    public class Bank
    {
        public Bank(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public bool Deposit(decimal amount, int accountNumber)
        {
            var account = Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account != null)
            {
                return account.Deposit(amount);
            }

            return false;
        }

        public bool Withdraw(decimal amount, int accountNumber)
        {
            var account = Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account != null)
            {
                return account.Withdraw(amount);
            }
         
            return false;
        }

        public bool Transfer(decimal amount, int fromAccountNumber, int toAccountNumber)
        {
            var fromAccount = Accounts.FirstOrDefault(a => a.AccountNumber == fromAccountNumber);
            var toAccount = Accounts.FirstOrDefault(a => a.AccountNumber == toAccountNumber);
            if (fromAccount != null && toAccount != null)
            {
                return fromAccount.Transfer(toAccount, amount);
            }
            return false;
        }


    }
}
