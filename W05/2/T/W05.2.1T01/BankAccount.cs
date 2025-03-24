public class BankAccount {
    private double _balance;
    protected int YearsPassed;
    protected double InterestRate;

    public BankAccount(double balance, double interestRate) {
        _balance = balance;
        InterestRate = interestRate;
        YearsPassed = 0;
    }

    public double ReadBalance() => _balance;

    public void Deposit(double depositAmount) {
        if (depositAmount > 0.0) {
            _balance += depositAmount;
        }
    }

    public virtual double Withdraw(double withdrawAmount) {
        if (SufficientBalance(withdrawAmount)) {
            if ((withdrawAmount - _balance) >= 0.0) {
                _balance -= withdrawAmount;
                return withdrawAmount;
            }
        }
        return 0.0;
    }

    public virtual void NextYear() => ApplyInterest();

    private void ApplyInterest() => _balance += _balance * InterestRate;

    // private bool SufficientBalance(double amount) => ((amount - _balance) > 0) ? true : false;

    private bool SufficientBalance(double amount) {
        double temp = _balance;
        if ((temp - amount) >= 0.0) {
            return true;
        }
        return false;
    }
}