using BankApp.Enums;

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
