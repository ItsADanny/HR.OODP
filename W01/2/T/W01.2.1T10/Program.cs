class Program {
    static void Main() {
        //You can also just simply do Console.WriteLine(rollDice(6)); 10 times
        //But i did it in a for-loop because its faster to do it this way
        for (int i = 0; i != 10; i++) {
            Console.WriteLine(rollDice(6));
        }
    }

    //You can simply use the code inside to print it every time
    //And print the result but i wanted it inside a function
    static int rollDice(int sides) {
        //We just add the 1 to the random so that we always get 2 as the result
        Random rnd = new Random(1);
        return rnd.Next(1, sides);
    }
}