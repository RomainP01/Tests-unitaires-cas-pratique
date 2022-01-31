package bank;

import lombok.Data;

import java.util.Arrays;
import java.util.List;

@Data
public class Bank {
    private List<BankAccount> bankAccountList = createBankContext();

    public List<BankAccount> createBankContext() {
        BankAccount bankAccount = new BankAccount(1, "Pani", "Romain", 6500.00);
        BankAccount bankAccount2 = new BankAccount(2, "Parker", "Peter", 271.99);
        BankAccount bankAccount3 = new BankAccount(3, "Stark", "Tony", 8799500.30);
        return Arrays.asList(bankAccount, bankAccount2, bankAccount3);
    }
}