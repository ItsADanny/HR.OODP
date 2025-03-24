static class Program
{
    static void Main()
    {
        //First we make a couple of booleans to see which directions are possible
        bool bool_show_north = false, bool_show_east = false, bool_show_south = false, bool_show_west = false;
        //Now we create a Integer in which we will store our bearing
        int int_bearing;

        //Now we ask for the directions
        Console.WriteLine("For each direction, input Y/N if it is valid.");
        //NORTH
        Console.WriteLine("North? Y/N");
        if (Console.ReadLine().ToLower() == "y") {
             bool_show_north = true;
        }
        //EAST
        Console.WriteLine("East? Y/N");
        if (Console.ReadLine().ToLower() == "y") {
             bool_show_east = true;
        }
        //SOUTH
        Console.WriteLine("South? Y/N");
        if (Console.ReadLine().ToLower() == "y") {
             bool_show_south = true;
        }
        //WEST
        Console.WriteLine("West? Y/N");
        if (Console.ReadLine().ToLower() == "y") {
             bool_show_west = true;
        }
        //Now we request the bearing
        Console.WriteLine("Give a bearing (a number) for the direction in which you are going.");
        //We convert the inputted bearing into a integer
        int_bearing = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("From here you can go:");

        //If we can go North, print that possibility
        if (bool_show_north) {
            Console.WriteLine("    N");
            Console.WriteLine("    |");
        }

        //Now we check the possibility for east and west, if so print that possibility
        if (bool_show_east & bool_show_west) {
            Console.WriteLine("W---|---E");
        //If we can only go east and not west then we print this possibility
        } else if (bool_show_east & !bool_show_west) {
            Console.WriteLine("    |---E");
        //If we can only go west and not east then we print this possibility
        } else if (!bool_show_east & bool_show_west) {
            Console.WriteLine("W---|");
        //If we can't go either east or west then we print a single line
        } else {
            Console.WriteLine("    |");
        }

        //And finally, if we can go south then we print that possibility
        if (bool_show_south) {
            Console.WriteLine("    |");
            Console.WriteLine("    S");
        }

        //Now we are going to see if our bearing is one we can work with,
        //if not we will continue reducing it until we can use it

        //First we make sure its within the range on the positive side
        if (int_bearing > 360) {
            while (int_bearing > 360) {
                //We reduce it by 360 to make it a valid bearing
                int_bearing -= 360;
            }
        }
        //Then we make sure its with in range from the negative side
        if (int_bearing < 0) {
            while (int_bearing < 0) {
                //We reduce it by 360 to make it a valid bearing
                int_bearing += 360;
            }
        }

        //Now Check the bearing to see which way the user is going
        //NORTH
        //Check if the bearing is in between these values
        if (int_bearing > 315 | int_bearing <= 45) {
            //Check if its possible to go into that direction
            if (bool_show_north) {
                Console.WriteLine("\nYou are going North");
            } else {
                Console.WriteLine("\nYou can't go North");
            }
        }
        //EAST
        //Check if the bearing is in between these values
        if (int_bearing > 45 & int_bearing <= 135) {
            if (bool_show_east) {
                Console.WriteLine("\nYou are going East");
            } else {
                Console.WriteLine("\nYou can't go East");
            }
        }
        //SOUTH
        //Check if the bearing is in between these values
        if (int_bearing > 135 & int_bearing <= 225) {
            //Check if its possible to go into that direction
            if (bool_show_south) {
                Console.WriteLine("\nYou are going South");
            } else {
                Console.WriteLine("\nYou can't go South");
            }
        }
        //WEST
        //Check if the bearing is in between these values
        if (int_bearing > 225 & int_bearing <= 315) {
            //Check if its possible to go into that direction
            if (bool_show_west) {
                Console.WriteLine("\nYou are going West");
            } else {
                Console.WriteLine("\nYou can't go West");
            }
        }
    }
}