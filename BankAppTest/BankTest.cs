using BankApp;
using FluentAssertions;

namespace BankAppTest
{
    public class BankTest
    {
        [Fact]
        public void Bank_AddAccount_AddsAccount()
        {
            /*
             * Given a new bank 
             * if we add an account
             * the bank contains the account
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new CheckingAccount(1, "Test Owner", 1000);
            // Act
            bank.AddAccount(account);
            // Assert
            Assert.Contains(account, bank.Accounts);
        }

        [Fact]
        public void Bank_Deposit_Fails_If_Account_Not_Found()
        {
            /*
             * Given a new bank
             * if we try to add to an account that does not exist
             * the deposit fails
             */

            // Arrange
            var bank = new Bank("Test Bank");
            // Act
            var result = bank.Deposit(100, 1);
            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Bank_Withdraw_Fails_If_Account_Not_Found()
        {
            /*
             * Given a bank
             * if we try to withdraw from an account that does not exist
             * the withdraw fails
             */

            //Arrange
            var bank = new Bank("Test Bank");
            //Act
            var result = bank.Withdraw(100, 1);
            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Bank_Transfer_Fails_If_Transfer_Account_Not_Found() {
            /*
             * Given a bank
             * And a transfer to account with 1000
             * if we try to transfer from an account that does not exist
             * the transfer to account still contains 1000
             * the transfer fails
             */

            //Arrange
            var bank = new Bank("Test Bank");
            var transferFromAccountNumber = 1;
            var transferToAccount = new CheckingAccount(2, "Test Owner", 1000);
            bank.AddAccount(transferToAccount);

            //Act
            var result = bank.Transfer(1, transferFromAccountNumber, transferToAccount.AccountNumber);

            //Assert
            transferToAccount.Balance.Should().Be(1000);
            result.Should().BeFalse();

        }

        [Fact]
        public void Bank_Transfer_Fails_If_Transfer_To_Account_Not_Found()
        {
            /*
             * Given a bank
             * And a account with 1000
             * if we try to transfer to an account that does not exist
             * the account still contains 1000
             * the transfer fails
             */

            //Arrange
            var bank = new Bank("Test Bank");
            var transferFromAccount = new CheckingAccount(1, "Test Owner", 1000);
            var transferToAccountNumber = 2;
            bank.AddAccount(transferFromAccount);

            //Act
            var result = bank.Transfer(1, transferFromAccount.AccountNumber, transferToAccountNumber);

            //Assert
            transferFromAccount.Balance.Should().Be(1000);
            result.Should().BeFalse();

        }
    }
}
