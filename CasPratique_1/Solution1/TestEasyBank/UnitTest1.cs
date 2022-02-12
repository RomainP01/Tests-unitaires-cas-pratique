using System;
using EasyBank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEasyBank
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestCreateNewBankAccount()
        {
            BankAccount bankAccount = new BankAccount(1, "Romain", "PANI", 10000.99);
            Assert.IsInstanceOfType(bankAccount, typeof(BankAccount));
            Assert.AreEqual("PANI", bankAccount.LastName);
            Assert.AreEqual("Romain", bankAccount.FirstName);
            Assert.AreEqual(10000.99, bankAccount.Balance);
        }
    }
}