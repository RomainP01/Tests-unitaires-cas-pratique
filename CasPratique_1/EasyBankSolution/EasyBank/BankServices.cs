using System;
using System.Collections.Generic;

namespace EasyBank
{
    public class BankServices
    {
        private List<BankAccount> _bankAccounts;

        public BankServices(List<BankAccount> bankAccounts)
        {
            _bankAccounts = bankAccounts;
        }

        public List<BankAccount> BankAccounts
        {
            get => _bankAccounts;
            set => _bankAccounts = value;
        }
        

        
        public BankAccount GetBankAccountById(int id)
        {
            foreach (var bankAccount in _bankAccounts)
            {
                if (bankAccount.Id == id)
                {
                    return bankAccount;
                }
            }
            throw new ArgumentException("Aucun compte avec l'identifiant renseigné a été trouvé");
        }

        public BankAccount Withdraw(BankAccount account, double amount)
        {
            if (amount <= account.Balance)
            {
                account.Balance -= amount;
                Console.WriteLine("Le retrait a bien été effectué");
                Console.WriteLine("Solde restant: "+account.Balance);
                return account;
            }else
            {
                throw new Exception("Retrait impossible : Solde du compte insuffisant");
            }
        }
    }
}