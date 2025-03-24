public class SavingsAccount : BankAccount {
    private bool _locked;

    public SavingsAccount(double balance, double interestRate) : base(balance, interestRate) => _locked = true;

    public override double Withdraw(double withdrawAmount)
    {
        if (!_locked) {
            return base.Withdraw(withdrawAmount);
        }
        return 0.0;
    }

    public override void NextYear()
    {
        YearsPassed++;
        if (YearsPassed < 5) {
            _locked = false;
        } else {
            base.NextYear();
        }
    }
}