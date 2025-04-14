class BankAccount : Account
{
    private int _balance;
    
    public BankAccount(string holderName, string password) : base(holderName, password) { }

    public void Deposit(int amount)
    {
        if (amount < 0)
            return;

        _balance += amount;
    }

    public int Withdraw(int amount)
    {
        if (!IsAuthenticated)
            return 0;
        if (amount >= _balance)
            return 0;

        _balance -= amount;
        return amount;
    }

    // Add methods Authenticate and PrintInfo
    protected override void Authenticate() {
        if (EnteredHolderName == HolderName && MyPassword.IsEnteredCredentialCorrect()) {
            IsAuthenticated = true;
        } else {
            IsAuthenticated = false;
        }
    }

    public override void PrintInfo() {
        if (IsAuthenticated) {
            Console.WriteLine($"Holder: {HolderName}\nBalance: {_balance}");
        } else {
            Console.WriteLine("Not authenticated");
        }
    }
}