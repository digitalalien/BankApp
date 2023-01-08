using BankApp;
using FluentAssertions;

namespace BankAppTest
{
    public class CheckingAccountTests
    {
        [Fact]
        public void Checking_Account_Deposit_ReturnsCorrectResult()
        {
            /*
             * Given a checking account
             * with a balance of 1000
             * when I deposit 1
             * then the balance should be 1001
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new CheckingAccount(1, "Test Owner", 1000m);
            bank.AddAccount(account);

            //Act
            var result = bank.Deposit(1m, account.AccountNumber);

            //Assert
            account.Balance.Should().Be(1001m);
            result.Should().BeTrue();
        }
        
        [Fact]
        public void Checking_Account_Deposit_Negative_Funds_Fails()
        {
            /*
             * Given a checking account
             * with a balance of 1000
             * when I deposit -1
             * then the balance should be 1000
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new CheckingAccount(1, "Test Owner", 1000m);
            bank.AddAccount(account);

            //Act
            var result = bank.Deposit(-1m, account.AccountNumber);

            //Assert
            account.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Checking_Account_Withdraw_ReturnsCorrectResult()
        {
            /*
             * Given a checking account
             * with a balance of 1000
             * when I withdraw 1
             * then the balance should be 999
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new CheckingAccount(1, "Test Owner", 1000m);
            bank.AddAccount(account);

            //Act
            var result = bank.Withdraw(1m, account.AccountNumber);

            //Assert
            account.Balance.Should().Be(999m);
            result.Should().BeTrue();
        }

        [Fact]
        public void Checking_Account_Withdraw_FailsForInsufficientFunds()
        {
            /*
             * Given a checking account
             * with a balance of 1000
             * when I withdraw 1001
             * then the balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new CheckingAccount(1, "Test Owner", 1000m);
            bank.AddAccount(account);

            //Act
            var result = bank.Withdraw(1001m, account.AccountNumber);

            //Assert
            account.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Checking_Account_Withdraw_Negative_Funds_Fails()
        {
            /*
             * Given a checking account
             * with a balance of 1000
             * when I withdraw -1
             * then the balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new CheckingAccount(1, "Test Owner", 1000m);
            bank.AddAccount(account);

            //Act
            var result = bank.Withdraw(-1m, account.AccountNumber);

            //Assert
            account.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Checking_Account_Transfer_To_Checking_Account_ReturnsCorrectResult()
        {
            /*
             * Given a checking account
             * with a balance of 1000
             * and another checking account
             * with a balance of 1000
             * when I transfer 1 from the checking account to the other checking account
             * then the checking account balance should be 999
             * and the other checking account balance should be 1001
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var checkingAccount1 = new CheckingAccount(1, "Test Owner", 1000m);
            var checkingAccount2 = new CheckingAccount(2, "Test Owner", 1000m);
            bank.AddAccount(checkingAccount1);
            bank.AddAccount(checkingAccount2);

            //Act
            var result = bank.Transfer(1m, checkingAccount1.AccountNumber, checkingAccount2.AccountNumber);

            //Assert
            checkingAccount1.Balance.Should().Be(999m);
            checkingAccount2.Balance.Should().Be(1001m);
            result.Should().BeTrue();
        }

        [Fact]
        public void Checking_Account_Transfer_To_Checking_Account_FailsForInsufficientFunds()
        {
            /*
             * Given a checking account
             * with a balance of 1000
             * and another checking account
             * with a balance of 1000
             * when I transfer 1001 from the checking account to the other checking account
             * then the checking account balance should be 1000
             * and the other checking account balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var checkingAccount1 = new CheckingAccount(1, "Test Owner", 1000m);
            var checkingAccount2 = new CheckingAccount(2, "Test Owner", 1000m);
            bank.AddAccount(checkingAccount1);
            bank.Accounts.Add(checkingAccount2);
            //Act
            var result = bank.Transfer(1001m, checkingAccount1.AccountNumber, checkingAccount2.AccountNumber);

            //Assert
            checkingAccount1.Balance.Should().Be(1000m);
            checkingAccount2.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Checking_Account_Transfer_Negative_Funds_Fails()
        {
            /*
             * Given a checking account
             * with a balance of 1000
             * and another checking account
             * with a balance of 1000
             * when I transfer -1 from the checking account to the other checking account
             * then the checking account balance should be 1000
             * and the other checking account balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var checkingAccount1 = new CheckingAccount(1, "Test Owner", 1000m);
            var checkingAccount2 = new CheckingAccount(2, "Test Owner", 1000m);
            bank.AddAccount(checkingAccount1);
            bank.Accounts.Add(checkingAccount2);
            //Act
            var result = bank.Transfer(-1m, checkingAccount1.AccountNumber, checkingAccount2.AccountNumber);

            //Assert
            checkingAccount1.Balance.Should().Be(1000m);
            checkingAccount2.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Checking_Account_Transfer_To_Individual_Investment_ReturnsCorrectResult()
        {
            /*
             * Given a checking account
             * with a balance of 1000
             * and an individual investment account
             * with a balance of 1000
             * when I transfer 1 from the checking account to the individual investment account
             * then the checking account balance should be 999
             * and the individual investment account balance should be 1001
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var checkingAccount = new CheckingAccount(1, "Test Owner", 1000m);
            var individualInvestmentAccount = new IndividualInvestmentAccount(2, "Test Owner", 1000m);
            bank.AddAccount(checkingAccount);
            bank.AddAccount(individualInvestmentAccount);

            //Act
            var result = bank.Transfer(1m, checkingAccount.AccountNumber, individualInvestmentAccount.AccountNumber);

            //Assert
            checkingAccount.Balance.Should().Be(999m);
            individualInvestmentAccount.Balance.Should().Be(1001m);
            result.Should().BeTrue();
        }

        [Fact]
        public void Checking_Account_Transfer_To_Individual_Investment_FailsForInsufficientFunds()
        {
            /*
             * Given a checking account
             * with a balance of 1000
             * and an individual investment account
             * with a balance of 1000
             * when I transfer 1001 from the checking account to the individual investment account
             * then the checking account balance should be 1000
             * and the individual investment account balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var checkingAccount = new CheckingAccount(1, "Test Owner", 1000m);
            var individualInvestmentAccount = new IndividualInvestmentAccount(2, "Test Owner", 1000m);
            bank.AddAccount(checkingAccount);
            bank.AddAccount(individualInvestmentAccount);

            //Act
            var result = bank.Transfer(1001m, checkingAccount.AccountNumber, individualInvestmentAccount.AccountNumber);

            //Assert
            checkingAccount.Balance.Should().Be(1000m);
            individualInvestmentAccount.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Checking_Account_Transfer_To_Corporate_Investment_ReturnsCorrectResult()
        {
            /*
             * Given a checking account
             * with a balance of 1000
             * and an corporate investment account
             * with a balance of 1000
             * when I transfer 1 from the checking account to the investment account
             * then the checking account balance should be 999
             * and the corporate investment account balance should be 1001
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var checkingAccount = new CheckingAccount(1, "Test Owner", 1000m);
            var corporateInvestmentAccount = new CorporateInvestmentAccount(2, "Test Owner", 1000m);
            bank.AddAccount(checkingAccount);
            bank.AddAccount(corporateInvestmentAccount);

            //Act
            var result = bank.Transfer(1m, checkingAccount.AccountNumber, corporateInvestmentAccount.AccountNumber);

            //Assert
            checkingAccount.Balance.Should().Be(999m);
            corporateInvestmentAccount.Balance.Should().Be(1001m);
            result.Should().BeTrue();
        }

        [Fact]
        public void Checking_Account_Transfer_To_Corporate_Investment_FailsForInsufficientFunds()
        {
            /*
             * Given a checking account
             * with a balance of 1000
             * and an corporate investment account
             * with a balance of 1000
             * when I transfer 1001 from the checking account to the investment account
             * then the checking account balance should be 1000
             * and the corporate investment account balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var checkingAccount = new CheckingAccount(1, "Test Owner", 1000m);
            var corporateInvestmentAccount = new CorporateInvestmentAccount(2, "Test Owner", 1000m);
            bank.AddAccount(checkingAccount);
            bank.AddAccount(corporateInvestmentAccount);

            //Act
            var result = bank.Transfer(1001m, checkingAccount.AccountNumber, corporateInvestmentAccount.AccountNumber);

            //Assert
            checkingAccount.Balance.Should().Be(1000m);
            corporateInvestmentAccount.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

    }
}