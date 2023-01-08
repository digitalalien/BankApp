using BankApp;
using FluentAssertions;

namespace BankAppTest
{
    public class CorporateInvestmentAccountTests
    {
        [Fact]
        public void Corporate_Investment_Account_Deposit_ReturnsCorrectResult()
        {
            /*
             * Given a corporate investment account
             * with a balance of 1000
             * when I deposit 1
             * then the balance should be 1001
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new CorporateInvestmentAccount(1, "Test Owner", 1000);
            bank.AddAccount(account);

            //Act
            bank.Deposit(1m, account.AccountNumber);

            //Assert
            account.Balance.Should().Be(1001m);
        }

        [Fact]
        public void Corporate_Investment_Account_Deposit_Negative_Funds_Fails()
        {
            /*
             * Given a corporate investment account
             * with a balance of 1000
             * when I deposit -1
             * then the balance should be 1000
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new CorporateInvestmentAccount(1, "Test Owner", 1000m);
            bank.AddAccount(account);

            //Act
            var result = bank.Deposit(-1m, account.AccountNumber);

            //Assert
            account.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Corporate_Investment_Account_Withdraw_ReturnsCorrectResult()
        {
            /*
             * Given a corporate investment account
             * with a balance of 1000
             * when I withdraw 1
             * then the balance should be 999
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new CorporateInvestmentAccount(1, "Test Owner", 1000);
            bank.AddAccount(account);

            //Act
            var result = bank.Withdraw(1m, account.AccountNumber);

            //Assert
            account.Balance.Should().Be(999m);
            result.Should().BeTrue();
        }

        [Fact]
        public void Corporate_Investment_Account_Withdraw_FailsForInsufficientFunds()
        {
            /*
             * Given a corporate investment account
             * with a balance of 1000
             * when I withdraw 1001
             * then the balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new CorporateInvestmentAccount(1, "Test Owner", 1000);
            bank.AddAccount(account);

            //Act
            var result = bank.Withdraw(1001m, account.AccountNumber);

            //Assert
            account.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Corporate_Investment_Account_Withdraw_Negative_Funds_Fails()
        {
            /*
             * Given a corporate investment account
             * with a balance of 1000
             * when I withdraw -1
             * then the balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new CorporateInvestmentAccount(1, "Test Owner", 1000m);
            bank.AddAccount(account);

            //Act
            var result = bank.Withdraw(-1m, account.AccountNumber);

            //Assert
            account.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Corporate_Investment_Account_Transfer_To_Individual_Investment_ReturnsCorrectResult()
        {
            /*
             * Given a corporate investment account
             * with a balance of 1000
             * and an individual investment account
             * with a balance of 1000
             * when I transfer 1 from the corporate investment account to the individual investment account
             * then the corporate investment account balance should be 999
             * and the individual investment account balance should be 1001
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var corporateInvestmentAccount = new CorporateInvestmentAccount(1, "Test Owner", 1000);
            var individualInvestmentAccount = new IndividualInvestmentAccount(2, "Test Owner", 1000);
            bank.AddAccount(corporateInvestmentAccount);
            bank.AddAccount(individualInvestmentAccount);

            //Act
            var result = bank.Transfer(1m, corporateInvestmentAccount.AccountNumber, individualInvestmentAccount.AccountNumber);

            //Assert
            corporateInvestmentAccount.Balance.Should().Be(999m);
            individualInvestmentAccount.Balance.Should().Be(1001m);
            result.Should().BeTrue();
        }

        [Fact]
        public void Corporate_Investment_Account_Transfer_To_Individual_Investment_FailsForInsufficientFunds()
        {
            /*
             * Given a corporate investment account
             * with a balance of 1000
             * and an individual investment account
             * with a balance of 1000
             * when I transfer 1001 from the corporate investment account to the individual investment account
             * then the corporate investment account balance should be 1000
             * and the individual investment account balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var corporateInvestmentAccount = new CorporateInvestmentAccount(1, "Test Owner", 1000);
            var individualInvestmentAccount = new IndividualInvestmentAccount(2, "Test Owner", 1000);
            bank.AddAccount(corporateInvestmentAccount);
            bank.AddAccount(individualInvestmentAccount);

            //Act
            var result = bank.Transfer(1001m, corporateInvestmentAccount.AccountNumber, individualInvestmentAccount.AccountNumber);

            //Assert
            corporateInvestmentAccount.Balance.Should().Be(1000m);
            individualInvestmentAccount.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Corporate_Investment_Account_Transfer_To_Checking_Account_ReturnsCorrectResult()
        {
            /*
             * Given a corporate investment account
             * with a balance of 1000
             * and an checking account
             * with a balance of 1000
             * when I transfer 1 from the corporate investment account to the checking account
             * then the corporate investment account balance should be 999
             * and the checking account balance should be 1001
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var corporateInvestmentAccount = new CorporateInvestmentAccount(1, "Test Owner", 1000);
            var checkingAccount = new CheckingAccount(2, "Test Owner", 1000);
            bank.AddAccount(corporateInvestmentAccount);
            bank.AddAccount(checkingAccount);

            //Act
            var result = bank.Transfer(1m, corporateInvestmentAccount.AccountNumber, checkingAccount.AccountNumber);

            //Assert
            corporateInvestmentAccount.Balance.Should().Be(999m);
            checkingAccount.Balance.Should().Be(1001m);
            result.Should().BeTrue();
        }

        [Fact]
        public void Corporate_Investment_Account_Transfer_To_Checking_Account_FailsForInsufficientFunds()
        {
            /*
             * Given a corporate investment account
             * with a balance of 1000
             * and an checking account
             * with a balance of 1000
             * when I transfer 1001 from the corporate investment account to the checking account
             * then the corporate investment account balance should be 1000
             * and the checking account balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var corporateInvestmentAccount = new CorporateInvestmentAccount(1, "Test Owner", 1000);
            var checkingAccount = new CheckingAccount(2, "Test Owner", 1000);
            bank.AddAccount(corporateInvestmentAccount);
            bank.AddAccount(checkingAccount);


            //Act
            var result = bank.Transfer(1001m, corporateInvestmentAccount.AccountNumber, checkingAccount.AccountNumber);

            //Assert
            corporateInvestmentAccount.Balance.Should().Be(1000m);
            checkingAccount.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Corporate_Investment_Account_Transfer_To_Corporate_Investment_ReturnsCorrectResult()
        {
            /*
             * Given a corporate investment account
             * with a balance of 1000
             * and another corporate investment account
             * with a balance of 1000
             * when I transfer 1 from the corporate investment account to the other corporate investment account
             * then the corporate investment account balance should be 999
             * and the other corporate investment account balance should be 1001
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var corporateInvestmentAccount1 = new CorporateInvestmentAccount(1, "Test Owner", 1000);
            var corporateInvestmentAccount2 = new CorporateInvestmentAccount(2, "Test Owner", 1000);
            bank.AddAccount(corporateInvestmentAccount1);
            bank.AddAccount(corporateInvestmentAccount2);

            //Act
            var result = bank.Transfer(1m, corporateInvestmentAccount1.AccountNumber, corporateInvestmentAccount2.AccountNumber);

            //Assert
            corporateInvestmentAccount1.Balance.Should().Be(999m);
            corporateInvestmentAccount2.Balance.Should().Be(1001m);
            result.Should().BeTrue();
        }

        [Fact]
        public void Corporate_Investment_Account_Transfer_To_Corporate_Investment_FailsForInsufficientFunds()
        {
            /*
             * Given a corporate investment account
             * with a balance of 1000
             * and another corporate investment account
             * with a balance of 1000
             * when I transfer 1001 from the corporate investment account to the other corporate investment account
             * then the corporate investment account balance should be 1000
             * and the other corporate investment account balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var corporateInvestmentAccount1 = new CorporateInvestmentAccount(1, "Test Owner", 1000);
            var corporateInvestmentAccount2 = new CorporateInvestmentAccount(2, "Test Owner", 1000);
            bank.AddAccount(corporateInvestmentAccount1);
            bank.AddAccount(corporateInvestmentAccount2);


            //Act
            var result = bank.Transfer(1001m, corporateInvestmentAccount1.AccountNumber, corporateInvestmentAccount2.AccountNumber);

            //Assert
            corporateInvestmentAccount1.Balance.Should().Be(1000m);
            corporateInvestmentAccount2.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Corporate_Investment_Account_Transfer_Negative_Funds_Fails()
        {
            /*
             * Given a corporate investment account
             * with a balance of 1000
             * and another corporate account
             * with a balance of 1000
             * when I transfer -1 from the checking account to the other corporate investment account
             * then the corporate investment account balance should be 1000
             * and the other corporate investment account balance should be 1000
             * and the method should return false
             */
            
            // Arrange
            var bank = new Bank("Test Bank");
            var corporateInvestmentAccount1 = new CorporateInvestmentAccount(1, "Test Owner", 1000m);
            var corporateInvestmentAccount2 = new CorporateInvestmentAccount(2, "Test Owner", 1000m);
            bank.AddAccount(corporateInvestmentAccount1);
            bank.Accounts.Add(corporateInvestmentAccount2);
            //Act
            var result = bank.Transfer(-1m, corporateInvestmentAccount1.AccountNumber, corporateInvestmentAccount2.AccountNumber);

            //Assert
            corporateInvestmentAccount1.Balance.Should().Be(1000m);
            corporateInvestmentAccount2.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

    }
}