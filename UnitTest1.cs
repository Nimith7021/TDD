namespace BankAccountTestApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOfIncreaseinBankBalanceOnDeposit()
        {
            Bank user1 = new Bank();
            user1.Deposit(1200);
            double expectedamount = 1200;
            Assert.AreEqual(user1.GetBalance(), expectedamount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Deposit Amount must be Positive")]
        public void TestExpectedBankOperations()
        {
            Bank user1 = new Bank();
            user1.Deposit(-1200);
            
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),"Withdraw amount must be positive")]

        public void TestOnWithdrawingMorethanBalance()
        {
            Bank user1 = new Bank();
            user1.Deposit(1000);
            user1.Withdraw(2000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Negative withdrawal Amount")]
        public void TestOnInvalidAmountToBeWithdrawn()
        {
            Bank user1 = new Bank();
            user1.Withdraw(-1200);

        }

        [TestMethod]
        public void CheckingWithdrawAmountWithBankBalance()
        {
            Bank user = new Bank();
            user.Deposit(5000);
            double pastBalance = user.GetBalance();
            double withdrawAmount = 2000;
            user.Withdraw(withdrawAmount);
            Assert.AreEqual(pastBalance-user.GetBalance(), withdrawAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),"Null Account Name")]

        public void TestOnInvalidBankAccountUserName()
        {
            Bank user1 = new Bank();
            Bank user2 = new Bank();
            user1.Transfer(null, 2000);
        }

        [TestMethod]

        public void TestOnIncreaseInReceiverBankAccountAndDecreaseInSenderAccount()
        {
            Bank user1 = new Bank();
            user1.Deposit(10000);
            double BalanceBeforeTransfer = user1.GetBalance();
            Bank user2 = new Bank();
            user2.Deposit(2000);
            double BalanceOfUser2BeforeDepositIntoAccount = user2.GetBalance();
            user1.Transfer(user2, 2000);
            double transferAmount = 2000;
            Assert.AreEqual(BalanceBeforeTransfer - user1.GetBalance(), transferAmount);
            Assert.AreEqual(user2.GetBalance(),transferAmount+BalanceOfUser2BeforeDepositIntoAccount);
        }
    }
}