int int_score = 0;

int_score += ask_question(["Which of the following is NOT a valid type in C#?"], ["A: bool", "B: int", "C: var", "D: string"], "c");
int_score += ask_question(["What happens if you execute the following line C#?", "int x = 1.23;"], ["A: x will be 1.23", "B: x will be 1", "C: x will be 1.0", "D: you will get a compiler error"], "d");
int_score += ask_question(["Consider the following line:", "double d = 1.23;", "What are TWO ways to convert variable d to an int?"], ["A: int i = (int)d;", "B: int i = int(d)", "C: int i = 0 + d", "D: int i = Convert.ToInt32(d)"], ["a", "d"]);

if (int_score == 3) {
    Console.WriteLine($"Your score: {int_score} out of 3. Well done!");
} else {
    Console.WriteLine($"Your score: {int_score} out of 3.");
}

int ask_question(List<string> ls_str_question, List<string> ls_str_possible_awnsers, correct_awnsers) {
    foreach (string str_line in ls_str_question) {
        Console.WriteLine(str_line);
    }
    foreach (string str_possible_awnser in ls_str_possible_awnsers) {
        Console.WriteLine(str_possible_awnser);
    }
    

    if (correct_awnsers is List<string>) {
        Console.WriteLine("Your first answer:");
        string str_choice_one = Console.ReadLine().ToLower();
        Console.WriteLine("Your second answer:");
        string str_choice_two = Console.ReadLine().ToLower();
        int both_correct = 0;
        foreach (string str_correct_awnser in correct_awnsers) {
            bool bool_good_awnser = false;
            if (str_correct_awnser == str_choice_one) {
                bool_good_awnser = true;
            } else if (str_correct_awnser == str_choice_two) {
                bool_good_awnser = true;
            }

            if (bool_good_awnser) {
                both_correct += 1;
            }
        }

        if (both_correct == 2) {
            return 1;
        } else {
            return 0;
        }
    } else {
        string str_choice = Console.ReadLine().ToLower();
        if (str_choice == correct_awnser) {
            return 1;
        } else {
            return 0;
        }
    }
}