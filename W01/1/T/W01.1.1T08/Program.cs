int int_pos_x = 0, int_pos_y = 0;

// Console.WriteLine("What direction would you like to go?");
string str_choice = Console.ReadLine();
switch (String.IsNullOrWhiteSpace(str_choice)) {
    case false:
        switch (str_choice.ToLower()) {
            case "up":
                int_pos_y++;
                break;
            case "down":
                int_pos_y--;
                break;
            case "right":
                int_pos_x++;
                break;
            case "left":
                int_pos_x--;
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
Console.WriteLine("X:" + int_pos_x + ", Y:" + int_pos_y);