using BankApp;
using FluentAssertions;

namespace BankAppTest
{
    public class IndividualInvestmentAccountTests
    {
        [Fact]
        public void Individual_Investment_Account_Deposit_ReturnsCorrectResult()
        {
            /*
             * Given a individual investment account
             * with a balance of 1000
             * when I deposit 1
             * then the balance should be 1001
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new IndividualInvestmentAccount(1, "Test Owner", 1000);
            bank.AddAccount(account);

            //Act
            bank.Deposit(1m, account.AccountNumber);

            //Assert
            account.Balance.Should().Be(1001m);
        }

        [Fact]
        public void Individual_Investment_Account_Deposit_Negative_Funds_Fails()
        {
            /*
             * Given a Individual investment account
             * with a balance of 1000
             * when I deposit -1
             * then the balance should be 1000
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new IndividualInvestmentAccount(1, "Test Owner", 1000m);
            bank.AddAccount(account);

            //Act
            var result = bank.Deposit(-1m, account.AccountNumber);

            //Assert
            account.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Individual_Investment_Account_Withdraw_ReturnsCorrectResult()
        {
            /*
             * Given a individual investment account
             * with a balance of 1000
             * when I withdraw 1
             * then the balance should be 999
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new IndividualInvestmentAccount(1, "Test Owner", 1000);
            bank.AddAccount(account);

            //Act
            var result = bank.Withdraw(1m, account.AccountNumber);

            //Assert
            account.Balance.Should().Be(999m);
            result.Should().BeTrue();
        }

        [Fact]
        public void Individual_Investment_Account_Withdraw_FailsForInsufficientFunds()
        {
            /*
             * Given a individual investment account
             * with a balance of 1000
             * when I withdraw 1001
             * then the balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new IndividualInvestmentAccount(1, "Test Owner", 1000);
            bank.AddAccount(account);

            //Act
            var result = bank.Withdraw(1001m, account.AccountNumber);

            //Assert
            account.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Individual_Investment_Account_Withdraw_Negative_Funds_Fails()
        {
            /*
             * Given a Individual investment account
             * with a balance of 1000
             * when I withdraw -1
             * then the balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new IndividualInvestmentAccount(1, "Test Owner", 1000m);
            bank.AddAccount(account);

            //Act
            var result = bank.Withdraw(-1m, account.AccountNumber);

            //Assert
            account.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }
        
        [Fact]
        public void Individual_Investment_Account_Transfer_To_Checking_Account_ReturnsCorrectResult()
        {
            /*
             * Given a Individual investment account
             * with a balance of 1000
             * and an checking account
             * with a balance of 1000
             * when I transfer 1 from the Individual investment account to the checking account
             * then the Individual investment account balance should be 999
             * and the checking account balance should be 1001
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var IndividualInvestmentAccount = new IndividualInvestmentAccount(1, "Test Owner", 1000);
            var checkingAccount = new CheckingAccount(2, "Test Owner", 1000);
            bank.AddAccount(IndividualInvestmentAccount);
            bank.AddAccount(checkingAccount);

            //Act
            var result = bank.Transfer(1m, IndividualInvestmentAccount.AccountNumber, checkingAccount.AccountNumber);

            //Assert
            IndividualInvestmentAccount.Balance.Should().Be(999m);
            checkingAccount.Balance.Should().Be(1001m);
            result.Should().BeTrue();
        }

        [Fact]
        public void Individual_Investment_Account_Transfer_To_Checking_Account_FailsForInsufficientFunds()
        {
            /*
             * Given a Individual investment account
             * with a balance of 1000
             * and an checking account
             * with a balance of 1000
             * when I transfer 1001 from the Individual investment account to the checking account
             * then the Individual investment account balance should be 1000
             * and the checking account balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var IndividualInvestmentAccount = new IndividualInvestmentAccount(1, "Test Owner", 1000);
            var checkingAccount = new CheckingAccount(2, "Test Owner", 1000);
            bank.AddAccount(IndividualInvestmentAccount);
            bank.AddAccount(checkingAccount);


            //Act
            var result = bank.Transfer(1001m, IndividualInvestmentAccount.AccountNumber, checkingAccount.AccountNumber);

            //Assert
            IndividualInvestmentAccount.Balance.Should().Be(1000m);
            checkingAccount.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Individual_Investment_Account_Transfer_To_Corporate_Investment_ReturnsCorrectResult()
        {
            /*
             * Given a Individual investment account
             * with a balance of 1000
             * and a corporate investment account
             * with a balance of 1000
             * when I transfer 1 from the Individual investment account to the corporate investment account
             * then the Individual investment account balance should be 999
             * and the  corporate investment account balance should be 1001
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var IndividualInvestmentAccount = new IndividualInvestmentAccount(1, "Test Owner", 1000);
            var corporateInvestmentAccount = new CorporateInvestmentAccount(2, "Test Owner", 1000);
            bank.AddAccount(IndividualInvestmentAccount);
            bank.AddAccount(corporateInvestmentAccount);

            //Act
            var result = bank.Transfer(1m, IndividualInvestmentAccount.AccountNumber, corporateInvestmentAccount.AccountNumber);

            //Assert
            IndividualInvestmentAccount.Balance.Should().Be(999m);
            corporateInvestmentAccount.Balance.Should().Be(1001m);
            result.Should().BeTrue();
        }

        [Fact]
        public void Individual_Investment_Account_Transfer_To_Corporate_Investment_FailsForInsufficientFunds()
        {
            /*
             * Given a Individual investment account
             * with a balance of 1000
             * and corporate investment account
             * with a balance of 1000
             * when I transfer 1001 from the Individual investment account to the corporate investment account
             * then the Individual investment account balance should be 1000
             * and the corporate investment account balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var IndividualInvestmentAccount = new IndividualInvestmentAccount(1, "Test Owner", 1000);
            var corporateInvestmentAccount = new CorporateInvestmentAccount(2, "Test Owner", 1000);
            bank.AddAccount(IndividualInvestmentAccount);
            bank.AddAccount(corporateInvestmentAccount);


            //Act
            var result = bank.Transfer(1001m, IndividualInvestmentAccount.AccountNumber, corporateInvestmentAccount.AccountNumber);

            //Assert
            IndividualInvestmentAccount.Balance.Should().Be(1000m);
            corporateInvestmentAccount.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Individual_Investment_Account_Transfer_To_Individual_Investment_ReturnsCorrectResult()
        {
            /*
             * Given a Individual investment account
             * with a balance of 1000
             * and an individual investment account
             * with a balance of 1000
             * when I transfer 1 from the Individual investment account to the individual investment account
             * then the Individual investment account balance should be 999
             * and the individual investment account balance should be 1001
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var individualInvestmentAccount1 = new IndividualInvestmentAccount(1, "Test Owner", 1000);
            var individualInvestmentAccount2 = new IndividualInvestmentAccount(2, "Test Owner", 1000);
            bank.AddAccount(individualInvestmentAccount1);
            bank.AddAccount(individualInvestmentAccount2);

            //Act
            var result = bank.Transfer(1m, individualInvestmentAccount1.AccountNumber, individualInvestmentAccount2.AccountNumber);

            //Assert
            individualInvestmentAccount1.Balance.Should().Be(999m);
            individualInvestmentAccount2.Balance.Should().Be(1001m);
            result.Should().BeTrue();
        }

        [Fact]
        public void Individual_Investment_Account_Transfer_To_Individual_Investment_FailsForInsufficientFunds()
        {
            /*
             * Given a Individual investment account
             * with a balance of 1000
             * and an individual investment account
             * with a balance of 1000
             * when I transfer 1001 from the Individual investment account to the individual investment account
             * then the Individual investment account balance should be 1000
             * and the individual investment account balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var individualInvestmentAccount1 = new IndividualInvestmentAccount(1, "Test Owner", 1000);
            var individualInvestmentAccount2 = new IndividualInvestmentAccount(2, "Test Owner", 1000);
            bank.AddAccount(individualInvestmentAccount1);
            bank.AddAccount(individualInvestmentAccount2);

            //Act
            var result = bank.Transfer(1001m, individualInvestmentAccount1.AccountNumber, individualInvestmentAccount2.AccountNumber);

            //Assert
            individualInvestmentAccount1.Balance.Should().Be(1000m);
            individualInvestmentAccount2.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }


        [Fact]
        public void Individual_Investment_Account_Transfer_Negative_Funds_Fails()
        {
            /*
             * Given a Individual investment account
             * with a balance of 1000
             * and another Individual account
             * with a balance of 1000
             * when I transfer -1 from the checking account to the other Individual investment account
             * then the Individual investment account balance should be 1000
             * and the other Individual investment account balance should be 1000
             * and the method should return false
             */
            
            // Arrange
            var bank = new Bank("Test Bank");
            var IndividualInvestmentAccount1 = new IndividualInvestmentAccount(1, "Test Owner", 1000m);
            var IndividualInvestmentAccount2 = new IndividualInvestmentAccount(2, "Test Owner", 1000m);
            bank.AddAccount(IndividualInvestmentAccount1);
            bank.Accounts.Add(IndividualInvestmentAccount2);
            //Act
            var result = bank.Transfer(-1m, IndividualInvestmentAccount1.AccountNumber, IndividualInvestmentAccount2.AccountNumber);

            //Assert
            IndividualInvestmentAccount1.Balance.Should().Be(1000m);
            IndividualInvestmentAccount2.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Individual_Investment_Account_Withdraw_Over_MaxWithdarw_Amount_Fails()
        {
            /*
             * Given a Individual investment account
             * with a balance of 1000
             * when I attempt to withdraw over the MaxWithdrawAmount from the Individual investment account
             * then the Individual investment account balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account = new IndividualInvestmentAccount(1, "Test Owner", 1000m);
            bank.AddAccount(account);

            //Act
            var result = bank.Withdraw(account.MaxWithdrawalAmount+1, account.AccountNumber);
            
            //Assert
            account.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

        [Fact]
        public void Individual_Investment_Account_Transfer_Over_MaxWithdrawAmount_Fails()
        {
            /*
             * Given a Individual investment account
             * with a balance of 1000
             * when I attempt to transfer over the MaxWithdrawAmount from the Individual investment account
             * then the Individual investment account balance should be 1000
             * and the method should return false
             */

            // Arrange
            var bank = new Bank("Test Bank");
            var account1 = new IndividualInvestmentAccount(1, "Test Owner", 1000m);
            var account2 = new IndividualInvestmentAccount(2, "Test Owner", 1000m);
            bank.AddAccount(account1);
            bank.AddAccount(account2);

            //Act
            var result = bank.Transfer(account1.MaxWithdrawalAmount+1, account1.AccountNumber, account2.AccountNumber);

            //Assert
            account1.Balance.Should().Be(1000m);
            account2.Balance.Should().Be(1000m);
            result.Should().BeFalse();
        }

    }
}