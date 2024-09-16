Int32 int32_wallet = 4;

while (int32_wallet != 0) {
    Console.WriteLine("Money left: " + int32_wallet);
    Console.WriteLine("Look around (1) or go in a ride (2)?");
    String str_choice = Console.ReadLine();
    switch (str_choice)
    {
        case "1":
            Console.WriteLine("Yay!");
            break;
        case "2":
            Console.WriteLine("Wheee!");
            int32_wallet--;
            break;        
    }
}
Console.WriteLine("Time to go home");