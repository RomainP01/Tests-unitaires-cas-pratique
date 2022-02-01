import bank.BankServices;
import exceptions.AccountNotFoundException;
import exceptions.InsufficientAmountException;

public class Main {
    public static void main(String[] args) throws  InsufficientAmountException {
        BankServices bankServices = new BankServices();
        System.out.println(bankServices.getBankAccountById(2));
        System.out.println(bankServices.withdraw(bankServices.getBankAccountById(2),35000));
    }

}
