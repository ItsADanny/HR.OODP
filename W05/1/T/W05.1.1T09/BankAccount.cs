public class BankAccount {
    private double _balance;

    public BankAccount(double balance) => _balance = balance;

    public double ReadBalance() => _balance;

    public void Deposit(double depositAmount) {
        if (depositAmount > 0.0) {
            _balance += depositAmount;
        }
    }

    public double Withdraw(double withdrawAmount) {
        if (SufficientBalance(withdrawAmount)) {
            if ((withdrawAmount - _balance) >= 0.0) {
                _balance -= withdrawAmount;
                return _balance;
            }
        }
        return 0.0;
    }

    // private bool SufficientBalance(double amount) => ((amount - _balance) > 0) ? true : false;

    private bool SufficientBalance(double amount) {
        double temp = _balance;
        if ((temp - amount) >= 0.0) {
            return true;
        }
        return false;
    }
}