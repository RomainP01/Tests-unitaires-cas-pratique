using System;
using System.Collections.Generic;
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
        
        [TestMethod]
        [Description("GIVEN: Etant donné une recherche de compte client, "+
                     "WHEN : lorsque je recherche le compte du client avec l'identifiant 2, "+
                     "THEN : alors l'objet BankAccount du client avec l'identifiant 2 est retourné")]
        public void Test_FindAnAccountById_Exist_ReturnBankAccount()
        {    
            //Arrange
            BankAccount bankAccount = new BankAccount(1, "Romain", "PANI", 10000.99);
            BankAccount bankAccount2 = new BankAccount(2, "Robert", "HALLIDAY", 10.53);
            List<BankAccount> list = new List<BankAccount>();
            list.Add(bankAccount);
            list.Add(bankAccount2);
            BankServices bankServices = new BankServices(list);
            
            //Act
            BankAccount bankAccountFindWithId = bankServices.GetBankAccountById(2);
            
            //Assert
            Assert.AreSame(bankAccountFindWithId,bankAccount2);

        }
        
        [TestMethod]
        [Description("GIVEN: Etant donné une recherche de compte client, "+
                     "WHEN : lorsque je recherche le compte du client avec l'identifiant 0, "+
                     "THEN : alors aucun client n'est trouvé et ainsi une Exception de type Argument Exception est levée")]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test_FindAnAccountById_NotExist_ReturnException()
        {    
            //Arrange
            BankAccount bankAccount = new BankAccount(1, "Romain", "PANI", 10000.99);
            BankAccount bankAccount2 = new BankAccount(2, "Robert", "HALLIDAY", 10.53);
            List<BankAccount> list = new List<BankAccount>();
            list.Add(bankAccount);
            list.Add(bankAccount2);
            BankServices bankServices = new BankServices(list);
            
            //Act & Assert
            BankAccount bankAccountFindWithId = bankServices.GetBankAccountById(0);

        }
    }
    
    
}