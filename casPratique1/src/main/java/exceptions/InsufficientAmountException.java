package exceptions;

public class InsufficientAmountException extends Exception {
    public InsufficientAmountException(String errorMessage) {
        super(errorMessage);
    }
}
