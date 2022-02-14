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
        [Description("GIVEN: Etant donné la création d'un compte client, "+
                     "WHEN : lorsque je crée un compte client ayant comme paramètre 1, Romain, PANI et 10000.99, "+
                     "THEN : alors un objet BankAccount du client est créé avec " +
                     "comme id=1, firstName=Romain, lastName=PANI et balance=10000.99")]
        public void Test_CreateNewBankAccount()
        {
            //Arrange and Act
            BankAccount bankAccount = new BankAccount(1, "Romain", "PANI", 10000.99);
            
            //Assert
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
        
        [TestMethod]
        [Description("GIVEN: Etant donné un retrait d'argent d'un compte client, "+
                     "WHEN : lorsque je retire une somme inférieur au total du compte du client, "+
                     "THEN : alors l'opération s'effectue et le compte client est retourné")]
        public void Test_WithdrawLessThanTheAccountBalance_Possible_ReturnAccount()
        {    
            //Arrange
            BankAccount bankAccount = new BankAccount(1, "Romain", "PANI", 10000.99);
            List<BankAccount> list = new List<BankAccount>();
            list.Add(bankAccount);
            BankServices bankServices = new BankServices(list);
            double oldAmount = bankAccount.Balance;
            
            //Act 
            BankAccount bankAccountGetWithdraw = bankServices.Withdraw(bankAccount, 200.00);
            Assert.AreSame(bankAccount,bankAccountGetWithdraw);
            Assert.AreEqual(oldAmount-200.00, bankAccountGetWithdraw.Balance);

        }
        
        [TestMethod]
        [Description("GIVEN: Etant donné un retrait d'argent d'un compte client, "+
                     "WHEN : lorsque je retire une somme supérieur au total du compte du client, "+
                     "THEN : alors l'opération ne s'effectue pas et une exception est levée")]
        [ExpectedException(typeof(Exception))]
        public void Test_WithdrawMoreThanTheAccountBalance_NotPossible_ReturnException()
        {    
            //Arrange
            BankAccount bankAccount = new BankAccount(1, "Romain", "PANI", 10000.99);
            List<BankAccount> list = new List<BankAccount>();
            list.Add(bankAccount);
            BankServices bankServices = new BankServices(list);
            double oldAmount = bankAccount.Balance;
            
            //Act & Assert
            BankAccount bankAccountGetWithdraw = bankServices.Withdraw(bankAccount, 200000.00);

        }
        
        [TestMethod]
        public void Test_ChangeLastNameOfAnAccount()
        {    
            //Arrange
            BankAccount bankAccount = new BankAccount(1, "Romain", "PAGNY", 10000.99);
            List<BankAccount> list = new List<BankAccount>();
            list.Add(bankAccount);
            BankServices bankServices = new BankServices(list);
            List<BankAccount> listOfAllAccounts = bankServices.BankAccounts;
            String oldLastName = "";
            BankAccount conceirnedBankAccount = bankAccount;
            //Act
            foreach (var account in listOfAllAccounts)
            {
                if (account.Id ==1)
                {
                    oldLastName = account.LastName; 
                    account.LastName = "PANI";
                    conceirnedBankAccount = account;
                }
            }
            
            //Assert
            Assert.AreNotEqual(conceirnedBankAccount.LastName,oldLastName);
            Assert.AreEqual("PANI",conceirnedBankAccount.LastName);

        }
        
        [TestMethod]
        public void Test_ChangeSurnameOfAnAccount()
        {    
            //Arrange
            BankAccount bankAccount = new BankAccount(1, "Romin", "PANI", 10000.99);
            List<BankAccount> list = new List<BankAccount>();
            list.Add(bankAccount);
            BankServices bankServices = new BankServices(list);
            List<BankAccount> listOfAllAccounts = bankServices.BankAccounts;
            String oldSurname = "";
            BankAccount conceirnedBankAccount = bankAccount;
            //Act
            foreach (var account in listOfAllAccounts)
            {
                if (account.Id ==1)
                {
                    oldSurname = account.FirstName; 
                    account.FirstName = "Romain";
                    conceirnedBankAccount = account;
                }
            }
            
            //Assert
            Assert.AreNotEqual(conceirnedBankAccount.FirstName,oldSurname);
            Assert.AreEqual("Romain",conceirnedBankAccount.FirstName);

        }
        
        [TestMethod]
        public void Test_AddAccountToExistingBankServices()
        {    
            //Arrange
            BankAccount bankAccount = new BankAccount(1, "Romain", "PANI", 10000.99);
            List<BankAccount> list = new List<BankAccount>();
            list.Add(bankAccount);
            BankServices bankServices = new BankServices(list);
            List<BankAccount> listOfAllAccounts = bankServices.BankAccounts;
            BankAccount newAccount = new BankAccount(2,"Jean-Paul", "Gautier",200000000.00);
            //Act
            listOfAllAccounts.Add(newAccount);
            bankServices.BankAccounts = listOfAllAccounts;
            
            //Assert
            Assert.AreEqual(2,bankServices.BankAccounts.Count);

        }
    }
    
    
}