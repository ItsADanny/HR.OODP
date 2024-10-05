/* Below is a map of 6 Locations.
 * The Player starts at 1 and the goal is to move to 6.
 * +---+
 * |123|
 * | 4 |
 * | 56|
 * +---+
 */

Player player = new Player(World.Locations[1]); //Creates a Player object and puts him at Location 1
// Console.WriteLine("Current location: " + player.CurrentLocation.Name);
// Console.WriteLine(player.CurrentLocation.Compass()); //Can be used to see the movement options
//
// player.TryMoveTo(player.CurrentLocation.GetLocationAt("E")); //Moves the Player to Location 2

/*
 * Write a while-loop that continues until the Player has arrived at the Goal.
 * This means that the Player's CurrentLocation Name should become "Goal".
 * At each iteration, ask the user for a direction (N/E/S/W), then try to move the Player.
 * For example:
 * - player.TryMoveTo(player.CurrentLocation.GetLocationAt("N")) will move the Player north IF there is a Location;
 * - player.TryMoveTo(null) will not move the Player.
 */

// VVV YOUR CODE GOES HERE VVV

//We begin by going into a loop until we have reached the location name "Goal"
while (player.CurrentLocation.Name != "Goal") {
    // We then Print 2 messages.
    //The current location
    Console.WriteLine("Current location: " + player.CurrentLocation.Name);
    //The compass for our current location
    Console.WriteLine(player.CurrentLocation.Compass());

    //We then request an input from the user and turn this to a Uppercase letter
    string str_choice = Console.ReadLine().ToUpper();
    //We then use a switch statement to make the movement direction based on the input
    switch (str_choice) {
        case "N":
            if (!player.TryMoveTo(player.CurrentLocation.GetLocationAt("N"))) {
                //If we can't move that way then we print an error message
                Console.WriteLine("Can't move that way");
            }
            break;
        case "E":
            if (!player.TryMoveTo(player.CurrentLocation.GetLocationAt("E"))) {
                //If we can't move that way then we print an error message
                Console.WriteLine("Can't move that way");
            }
            break;
        case "S":
            if (!player.TryMoveTo(player.CurrentLocation.GetLocationAt("S"))) {
                //If we can't move that way then we print an error message
                Console.WriteLine("Can't move that way");
            }
            break;
        case "W":
            if (!player.TryMoveTo(player.CurrentLocation.GetLocationAt("W"))) {
                //If we can't move that way then we print an error message
                Console.WriteLine("Can't move that way");
            }
            break;
    }
}

// ^^^YOUR CODE GOES HERE ^^^

Console.WriteLine("You have arrived at the goal!");