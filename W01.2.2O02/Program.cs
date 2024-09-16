bool bool_valid_color = false;
string str_color_choice = null;
do {
    Console.WriteLine("Pick a color (red/blue/green/yellow):");
    switch (Console.ReadLine().ToLower())
    {
        case "red":
            bool_valid_color = true;
            str_color_choice = "red";
            break;
        case "blue":
            bool_valid_color = true;
            str_color_choice = "blue";
            break;
        case "green":
            bool_valid_color = true;
            str_color_choice = "green";
            break;
        case "yellow":
            bool_valid_color = true;
            str_color_choice = "yellow";
            break;
    }
} while (!bool_valid_color);

bool bool_valid_number = false;
int int_number = 0;
do {
    Console.WriteLine("Pick a color (red/blue/green/yellow):");
    Int32 int_selected_number = Convert.ToInt32(Console.ReadLine());
    if (int_selected_number >= 1 & int_selected_number <= 8)
    {
        bool_valid_number = true;
        int_number = int_selected_number;
    }
} while (!bool_valid_number);

int fortuneNumber = ((str_color_choice.Length() + int_number) % 4);
if (fortuneNumber >= 0 & fortuneNumber <= 3) { 
    fortuneNumber++;
}

PrintFortune(fortuneNumber);

static void PrintFortune(int fortuneNumber)
{
    string fortune = fortuneNumber switch
    {
        1 => "You will be loved and be happy!",
        2 => "You will be loved and be rich!",
        3 => "You will be loved and be famous!",
        4 => "You will be loved, and you'll be happy, rich and famous!",
        _ => "Unknown. :( But you will still be loved, no matter what."
    };
    Console.WriteLine(fortune);
}