package bank;

import lombok.Data;

@Data
public class BankAccount {
    private int id;
    private String firstName;
    private String lastName;
    private Double balance;

    public BankAccount(int id, String firstName, String lastName, Double balance) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
}
