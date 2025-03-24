//We start by creating the BankAccount class
class BankAccount {
    //Add 2 field to the class 1 static double which will hold our
    //interest rate percentage, and one that will hold our BankAccounts
    //balance
    public static double InterestPercentage;
    public double Balance;

    //Now create a method for depositing money into the account
    public void Deposit(double money) => Balance += money;

    //Now create a method for Applying Interest to the balance of 
    //the account
    public void ApplyInterest() => Balance += (InterestPercentage / 100) * Balance;
}