static class Program
{
    static void Main()
    {
        //ORIGINAL PROGRAM CODE
        //==========================================================================================
        Random rand = new(0);
        var howManyTimes = 500;
        var dieSides = 6;

        List<List<int>> results = new();
        for (int i = 0; i < howManyTimes; i++)
        {
            List<int> rollResults = new();
            for (int j = 0; j < 2; j++)
            {
                rollResults.Add(rand.Next(1, dieSides + 1));
            }
            results.Add(rollResults);
        }

        List<string> freqs = new()
        {
            " 2: ",
            " 3: ",
            " 4: ",
            " 5: ",
            " 6: ",
            " 7: ",
            " 8: ",
            " 9: ",
            "10: ",
            "11: ",
            "12: ",
        };
        //==========================================================================================
        //Assignment description
        /*
        * Your code goes here.
        * List 'results' is a nested List. Each inner List contain two numbers.
        * For each inner List, you need to sum the two numbers, then update 'freqs'.
        * For example, if the sum of the two dice is 7, add a pipe to the string "7: ".
        */
        //==========================================================================================

        //We start by making a for-loop which loop until it has reached the count of our results list
        for (int i = 0; i != results.Count(); i++) {
            //From the results we retriev the first dices result and the second dices result
            int diceOneResult = results[i][0];
            int diceTwoResult = results[i][1];
            //We add this up and get the final result
            int totalResult = diceOneResult + diceTwoResult;

            //We then loop until we have reached the count of our freqs list
            for (int e = 0; e != freqs.Count(); e++) {
                //If the totalResult (-2) is the same as our current position in the freqs list then we add a pipe ("|") to our freq string on that position
                if (e == (totalResult - 2)) {
                    freqs[e] += "|";
                }
            }
        }

        //And finally we print the freqs
        foreach (string freq in freqs) {
            Console.WriteLine(freq);
        }
    }
}