static class Program
{
    static void Main()
    {
        BankAccount account1 = new();
        BankAccount account2 = new();

        account1.Deposit(1000);
        account2.Deposit(2000);

        BankAccount.InterestPercentage = 10;
        account1.ApplyInterest();

        BankAccount.InterestPercentage = 5;
        account1.ApplyInterest();
        account2.ApplyInterest();

        Console.WriteLine(account1.Balance);
        Console.WriteLine(account2.Balance);
    }
}