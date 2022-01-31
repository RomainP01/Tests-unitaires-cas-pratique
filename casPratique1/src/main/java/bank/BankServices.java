package bank;

import exceptions.AccountNotFoundException;
import exceptions.InsufficientAmountException;

import java.util.List;


public class BankServices {
    Bank bank = new Bank();

    public BankAccount getBankAccountById(int id) throws AccountNotFoundException {
        List<BankAccount> list = bank.getBankAccountList();
        for (BankAccount bankAccount : list) {
            if (bankAccount.getId() == id) {
                return bankAccount;
            }
        }
        throw new AccountNotFoundException("Le compte avec l'identifiant: " + id + " n'existe pas ou n'a pas été trouvé.");
    }

    public BankAccount withdraw(BankAccount account, double amount) throws InsufficientAmountException {
        if (account.getBalance() >= amount) {
            double accountBalance = account.getBalance();
            account.setBalance(accountBalance -= amount);
            return account;
        } else {
            throw new InsufficientAmountException("Montant insuffisant.");
        }
    }
}
