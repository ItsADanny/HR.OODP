string str_word_to_guess = "Length", str_guess;

Console.WriteLine("You have one chance to guess this six-letter word:");
Console.WriteLine("Le..th");

str_guess = Console.ReadLine();

if (str_guess.Length == 6) {
    if (str_guess == str_word_to_guess) {
        Console.WriteLine("Correct!");
    } else if (str_guess.ToLower() == str_word_to_guess.ToLower()) {
        Console.WriteLine("Kind of correct; the case was just wrong (hint: use ToLower())");
    } else {
        Console.WriteLine("Incorrect!");
    }
} else {
    Console.WriteLine("Incorrect! That is not even a six-letter word!");
}