bool bool_show_north = false, bool_show_east = false, bool_show_south = false, bool_show_west = false;
Int32 int32_bearing;

Console.WriteLine("For each direction, input Y/N if it is valid.");
Console.WriteLine("North? Y/N");
if (Console.ReadLine().ToLower() == "Y") {
    bool_show_north = true;
}
Console.WriteLine("East? Y/N");
if (Console.ReadLine().ToLower() == "Y") {
    bool_show_east = true;
}
Console.WriteLine("South? Y/N");
if (Console.ReadLine().ToLower() == "Y") {
    bool_show_south = true;
}
Console.WriteLine("West? Y/N");
if (Console.ReadLine().ToLower() == "Y") {
    bool_show_west = true;
}
Console.WriteLine("Give a bearing (a number) for the direction in which you are going.");
int32_bearing = Convert.ToInt32(Console.ReadLine());
show_result();

void show_result() {
    Console.WriteLine("From here you can go:");

    if (bool_show_north) {
        Console.WriteLine("    N");
        Console.WriteLine("    |");
    }

    if (bool_show_east || bool_show_west) {
        Console.WriteLine("W---|---E");
    } else if (bool_show_east & !bool_show_west) {
        Console.WriteLine("    |---E");
    } else if (!bool_show_east & bool_show_west) {
        Console.WriteLine("W---|");
    } else {
        Console.WriteLine("    |");
    }

    if (bool_show_south) {
        Console.WriteLine("    |");
        Console.WriteLine("    S");

    }

    if (int32_bearing > 360) {
        int32_bearing = int32_bearing - 360;
    }

    // switch (int32_bearing)
    // {
    //     case () {

    //     }
    //     default:
    // }
}