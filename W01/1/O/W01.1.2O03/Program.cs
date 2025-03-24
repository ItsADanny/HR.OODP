static class Program
{
    static void Main()
    {
        //First we make a variable which will keep the score
        int int_score = 0;

        //Then we print a starting message
        Console.WriteLine("Answer the following MCQs:");

        //First question
        //===========================================================================================
        //we ask question 1
        Console.WriteLine("Which of the following is NOT a valid type in C#?");
        //Then we print the possible awnsers for Question 1
        Console.WriteLine("A: bool\nB: int\nC: var\nD: string");
        //We then request an input from the user
        string str_awnserOne = Console.ReadLine();
         // Then we check if the awnser was correct, if so then we increase the users score by 1
        if (str_awnserOne.ToLower() == "c") {
             int_score++;
        }

        //Second question
        //===========================================================================================
        //we ask question 2
        Console.WriteLine("What happens if you execute the following line C#?\nint x = 1.23;");
        //Then we print the possible awnsers for Question 2
        Console.WriteLine("A: x will be 1.23\nB: x will be 1\nC: x will be 1.0\nD: you will get a compiler error");
        //We then request an input from the user
        string str_awnserTwo = Console.ReadLine();
         // Then we check if the awnser was correct, if so then we increase the users score by 1
        if (str_awnserTwo.ToLower() == "d") {
             int_score++;
        }

        //Third question
        //===========================================================================================
        //we ask question 3
        Console.WriteLine("Consider the following line:\ndouble d = 1.23;\nWhat are TWO ways to convert variable d to an int?");
        //Then we print the possible awnsers for Question 3
        Console.WriteLine("A: int i = (int)d;\nB: int i = int(d)\nC: int i = 0 + d\nD: int i = Convert.ToInt32(d)");
        //We print that we would like the users first awnser
        Console.WriteLine("Your first answer:");
        //We then request our first input from the user
        string str_awnserThree_reqOne = Console.ReadLine();
         //We print that we would like the users second awnser
        Console.WriteLine("Your second answer:");
        //We then request our second input from the user
        string str_awnserThree_reqTwo = Console.ReadLine();
         // Then we check if the awnsers were correct, if so then we increase the users score by 1
        if (str_awnserThree_reqOne.ToLower() == "a" & str_awnserThree_reqTwo.ToLower() == "d" | str_awnserThree_reqOne.ToLower() == "d" & str_awnserThree_reqTwo.ToLower() == "a") {
             int_score++;
        }

        //Now we check what the player has scored and print the appriopriate line
        if (int_score == 3) {
            Console.WriteLine($"Your score: {int_score} out of 3. Well done!");
        } else {
            Console.WriteLine($"Your score: {int_score} out of 3.");
        }
    }
}