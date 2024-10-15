double initialBalance = 0.0;
double paidTax = 0.0;
double interestRate = 0.05;

Console.WriteLine("Balance: ");
double initialBalance = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("years: ");
int yearAmount = Convert.ToInt32(Console.ReadLine());

for (int year = 1; year != yearAmount; year++)
{
    interestedBalance += initialBalance * interestRate;


    double calcTax = 0.0;

    if (interestedBalance > 100_000)
    {
        calcTax += (interestedBalance - 100_000) * 0.03;
        calcTax += (interestedBalance - 50_000) * 0.015;
    }
    else if (interestedBalance > 50_000)
    {
        calcTax += (interestedBalance - 50_000) * 0.015;
    }

    double finalBalance += interestedBalance - calcTax;

    double taxTotal += calcTax

}