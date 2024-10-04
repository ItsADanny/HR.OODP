class SavingsAccount : Account {
    public const double InterestRate = 0.05;

    public SavingsAccount (double balance) : base (balance) { }

    public void ApplyInterest() => Balance *= (1 + InterestRate);
}