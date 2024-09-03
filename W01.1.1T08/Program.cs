String str_choice;
Int32 int32_pos_x = 0, int32_pos_y = 0;

Console.WriteLine("What direction would you like to go?");
Int32 i = 0;
while (i != 5) {
    str_choice = Console.ReadLine().ToLower();

    switch (str_choice)
    {
        case "up":
            int32_pos_y++;
            break;
        case "down":
            int32_pos_y--;
            break;
        case "right":
            int32_pos_x++;
            break;
        case "left":
            int32_pos_x--;
            break;
        default:
            Console.WriteLine("Invalid direction");
            break;
    }

    i++;
}

Console.WriteLine("Current position");
Console.WriteLine("X:" + int32_pos_x + ", Y:" + int32_pos_y);