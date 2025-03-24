//We start by creating two variables,
//Both of them double and in these we are going to store our balance and the amount of taxes we paid.
double balance = 0.0;
double taxesPaid = 0.0;

//We then request 3 variables from the user. a Balance, a interest rate and the amount of years over which we need to calulate
Console.WriteLine("What is the initial balance in whole Euros?");
balance = Convert.ToDouble(Console.ReadLine());
//Because we need interest rate as a percentage we are going to divide our inputted interest by 100 so we can use it for our calculations
Console.WriteLine("What is the interest rate in percent?");
double interestRate = Convert.ToDouble(Console.ReadLine()) / 100;
Console.WriteLine("Calculate over how many years?");
double amountOfYears = Convert.ToDouble(Console.ReadLine());

//Now we are going to enter a for-loop until we have reached the number of years the user has put in
for (int year = 0; year != amountOfYears; year++) {
    //First we are going calculate the amount of interest we have gained and add this to our balance
    balance += balance * interestRate;

    //Then we are going to check how much tax we need to pay.
    //Based on how much money we have saved in our account we need to pay an certain amount of tax.
    //These are the amount:
    //1. for the first 50.000,- euro we don't pay any tax
    //2. after the first 50.000,- euro until 100.000,- we pay a tax rate of 1.5%
    //3. over everything above 100.000,- euro we pay a tax rate of 3%

    //First we remove the tax free part of the balance
    double taxablePart = balance - 50000;
    //Now we check if there is any money we need to still pay tax over
    if (taxablePart > 0) {
        //We check to see if the taxable part of our balance is higher than 50.000,- euro
        if (taxablePart > 50000) {
            //Since we know that the lower part of the tax rate is 1.5% over 50.000,- euro we can just set our lowTax to 750
            double lowTax = 750;
            //And then calculate our High tax part with 3% tax.
            double highTax = (taxablePart - 50000) * 0.03;
            //Then we add this tax to the tax amount we payed and subtract it from our new balance
            taxesPaid += lowTax;
            balance -= lowTax;
            taxesPaid += highTax;
            balance -= highTax;
        } else {
            Console.WriteLine("Kom ik hier???, Lijn 40");
            //If we only need to pay the lower tax rate then we just simply calulate the amount of tax we need to pay.
            double lowTax = taxablePart * 0.015;
            //Then we add this tax to the tax amount we payed and subtract it from our new balance
            taxesPaid += lowTax;
            balance -= lowTax;
        }
    }
}

//After we are done with our calculations we return the results to the user
Console.WriteLine($"Balance after {amountOfYears} years: {(int) balance}");
Console.WriteLine($"Amount of taxes paid: {(int) taxesPaid}");