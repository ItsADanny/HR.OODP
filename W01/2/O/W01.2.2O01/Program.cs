//We begin by making two variables.
//int_amount where we are going to store how much needs to be payed
//int_amount_payed where we are going to store how much we payed. This field will start with a default value of 0
int int_amount;
int int_amount_payed = 0;

//We print a message with the Question of how much is the amount that needs to be payed
Console.WriteLine("What is the amount to pay?");
//Then we request an input from the user and convert his integer input into a 32-Bit integer
int_amount = Convert.ToInt32(Console.ReadLine());

//Then we enter a while loop that will continue to run until int_amount has reached 0
while (int_amount > 0) {
    //We show how much needs to be payed and his options for paying with a 5 euro bill, 10 euro bill, 20 euro bill or a 50 euro bill
    Console.WriteLine(" ");
    Console.WriteLine($"{int_amount} left to pay");
    Console.WriteLine("Pay how much?");
    Console.WriteLine("1: 5");
    Console.WriteLine("2: 10");
    Console.WriteLine("3: 20");
    Console.WriteLine("4: 50");
    //Then we request the payment choice from the user
    string str_choice = Console.ReadLine();
     //After that we enter a switch statement that will use the chosen option to subtract the chosen option from the int_amount variable and add the chosen 
    //option to int_amount_payed
    switch (str_choice)
    {
        case "1":
            int_amount -= 5;
            int_amount_payed += 5;
            break;
        case "2":
            int_amount -= 10;
            int_amount_payed += 10;
            break;
        case "3":
            int_amount -= 20;
            int_amount_payed += 20;
            break;
        case "4":
            int_amount -= 50;
            int_amount_payed += 50;
            break;
    }
}

//After we exit the loop, we check to see if we have payed exactly wat was needed to pay the original bill, if not we are going to ask the
//user if he wants to give what he payed to much as a tip, if so print what we have payed, else we subtract what he payed to much and print the result
if (int_amount < 0) {
    Console.WriteLine($"You paid {int_amount * -1} too much. Give a tip? y/n");
    if (Console.ReadLine().ToLower() == "y") {
         Console.WriteLine($"You have paid {int_amount_payed}");
    } else {
        Console.WriteLine($"You have paid {int_amount_payed - (int_amount * -1)}");
    }
} else {
    Console.WriteLine($"You have paid {int_amount_payed}");
}