Int32 int32_amount, int32_amount_payed;

Console.WriteLine("What is the amount to pay?");
int32_amount = Convert.ToInt32(Console.ReadLine());
int32_amount_payed = int32_amount;

while (int32_amount >= 0) {
    Console.WriteLine(" ");
    Console.WriteLine($"{int32_amount} left to pay");
    Console.WriteLine("Pay how much?");
    Console.WriteLine("1: 5");
    Console.WriteLine("2: 10");
    Console.WriteLine("3: 20");
    Console.WriteLine("4: 50");
    String str_choice = Console.ReadLine();
    switch (str_choice)
    {
        case "1":
            int32_amount -= 5;
            int32_amount_payed += 5;
            break;
        case "2":
            int32_amount -= 10;
            int32_amount_payed += 10;
            break;
        case "3":
            int32_amount -= 20;
            int32_amount_payed += 20;
            break;
        case "4":
            int32_amount -= 50;
            int32_amount_payed += 50;
            break;
    }
}

if (int32_amount < 0) {
    Console.WriteLine($"You paid {int32_amount * -1} too much. Give a tip? y/n");
    if (Console.ReadLine().ToLower() == "y") {
        Console.WriteLine($"You have paid {int32_amount_payed}");
    } else {
        Console.WriteLine($"You have paid {int32_amount_payed - (int32_amount * -1)}");
    }
} else {
    Console.WriteLine($"You have paid {int32_amount_payed}");
}