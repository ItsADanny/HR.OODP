//We begin by asking the user a valid color, to do this we are first going to put the user in a do-while loop until we have received a valid anwser
//For this we are going to use a bool called bool_valid_color. This variable will continue to be false until we receive a valid color and after that
//we will exit the do-while loop and continue the program
bool bool_valid_color = false;
string str_color_choice = null;
 do {
    Console.WriteLine("Pick a color (red/blue/green/yellow):");
    switch (Console.ReadLine().ToLower())
     {
        case "red":
            //In case the selected color is RED we set the bool_valid_color to true and set the str_color_choice to "red"
            bool_valid_color = true;
            str_color_choice = "red";
            break;
        case "blue":
            //In case the selected color is BLUE we set the bool_valid_color to true and set the str_color_choice to "blue"
            bool_valid_color = true;
            str_color_choice = "blue";
            break;
        case "green":
            //In case the selected color is GREEN we set the bool_valid_color to true and set the str_color_choice to "green"
            bool_valid_color = true;
            str_color_choice = "green";
            break;
        case "yellow":
            //In case the selected color is YELLOW we set the bool_valid_color to true and set the str_color_choice to "yellow"
            bool_valid_color = true;
            str_color_choice = "yellow";
            break;
    }
} while (!bool_valid_color);

//Now we need a valid number between 1 and 8, to do this we are first going to put the user in a do-while loop until we have received a valid anwser
//For this we are going to use a bool called bool_valid_number. This variable will continue to be false until we receive a valid color and after that
//we will exit the do-while loop and continue the program
bool bool_valid_number = false;
int int_number = 0;
do {
    //We print a line in the console to ask the user to input a number between 1 and 8
    Console.WriteLine("Pick a number (1-8):");
    //We then request an input from the user and convert this input into a integer
    int int_selected_number = Convert.ToInt32(Console.ReadLine());
    //Then we check to see if this is a number between 1 and 8, if so update the bool_valid_number to true and save the selected number in out int_number variable
    if (int_selected_number >= 1 & int_selected_number <= 8)
    {
        bool_valid_number = true;
        int_number = int_selected_number;
    }
} while (!bool_valid_number);

//Now we use the length of our selected colors string and add this up to the integer.
//Then we get the remainder from 4 and check if our selected number is between 0 and 3.
//If so increase our fortunenumber by one
int fortuneNumber = (str_color_choice.Length + int_number) % 4;
 if (fortuneNumber >= 0 & fortuneNumber <= 3) { 
    fortuneNumber++;
}

//Then we print our * '. ,'* Fortune *.' ,*
PrintFortune(fortuneNumber);

//This is from the template for this assignment
//================================================================================================================
static void PrintFortune(int fortuneNumber)
{
    string fortune = fortuneNumber switch
    {
        1 => "You will be loved and happy!",
        2 => "You will be loved and rich!",
        3 => "You will be loved and famous!",
        4 => "You will be loved, happy, rich, and famous!",
        _ => "Unknown. :( But you will still be loved, no matter what."
    };
    Console.WriteLine(fortune);
}