package exceptions;

public class InsufficientAmountException extends RuntimeException {
    public InsufficientAmountException(String errorMessage) {
        super(errorMessage);
    }
}
