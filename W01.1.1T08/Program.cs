Int32 int32_pos_x = 0, int32_pos_y = 0;

// Console.WriteLine("What direction would you like to go?");
Int32 i = 0;
string str_choice = Console.ReadLine();
switch (String.IsNullOrWhiteSpace(str_choice)) {
    case false:
        switch (str_choice.ToLower()) {
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
        break;
    default:
        Console.WriteLine("Invalid input");
        break;
}

Console.WriteLine("Current position");
Console.WriteLine("X:" + int32_pos_x + ", Y:" + int32_pos_y);
